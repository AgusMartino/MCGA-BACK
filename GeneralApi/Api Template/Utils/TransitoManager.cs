using GeneralApi.Entities;
using GeneralApi.Entities.Enums;
using GeneralApi.Models.Telepeaje;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Util;

namespace GeneralApi.Utils
{
    public class TransitoManager
    {
        #region Public methods
        public static object GetTransitoGenerado()
        {
            using (var db = new TELEPEAJEEntities())
            {
                var transitoGenerado = GetTransitoTotal();
                return transitoGenerado;
            }

        }
        public static List<TransaccionDTO> GetPagosEmitidos()
        {
            return GetPatentesPorEstado(CommonEnums.TipoEstadoEnum.Pago.ToString());
        }

        public static List<TransaccionDTO> GetMultasEmitidas()
        {
            return GetPatentesPorEstado(CommonEnums.TipoEstadoEnum.Multa.ToString());
        }



        public static object GetTotalFacturado()
        {
            var totalTransito = GetTransitoTotal();
            decimal totalFacturado = 0;
            foreach (var item in totalTransito)
            {
                totalFacturado += item.monto;
            }
            return new
            {
                totalFacturadoHastaFecha = DateTime.Now,
                totalFacturadoMonto = String.Format("${0}", totalFacturado.ToString("0.00"))
            };
        }

        public static object GetCantidadVehiculosNoReconocidos()
        {
            var cant = GetTransitoTotal()
                .Where(x => x.estado == CommonEnums.TipoEstadoEnum.Multa.ToString())
                .GroupBy(x => x.patente)
                .Count();
            return new
            {
                cantidadVehiculosNoReconocidos = cant,
                fecha = DateTime.Now
            };
        }

        public static object GetCantidadVehiculosReconocidos()
        {
            var cant = GetTransitoTotal()
                .Where(x => x.estado == CommonEnums.TipoEstadoEnum.Pago.ToString())
                .GroupBy(x => x.patente)
                .Count();
            return new
            {
                cantidadVehiculosReconocidos = cant,
                fecha = DateTime.Now
            };
        }

        #endregion

        #region Private methods

        private static List<TransaccionDTO> GetPatentesPorEstado(string estado)
        {
            using (var db = new TELEPEAJEEntities())
            {
                var transitoGenerado =
                    (from trans in GetTransitoTotal()
                     where trans.estado.ToLower() == estado.ToLower()
                     select trans
                     ).ToList();

                return transitoGenerado;
            }
        }
        private static List<TransaccionDTO> GetTransitoTotal()
        {
            using (var db = new TELEPEAJEEntities())
            {
                var transitoGenerado = (from trans in db.Transacciones
                                        from est in db.Estadoes
                                        from pat in db.Patentes
                                        from ve in db.Tipo_Vehiculo
                                        where
                                        trans.Estado.ID_Estado == est.ID_Estado
                                        && trans.ID_Patente == pat.ID_Patente
                                        && pat.ID_Tipo_Vehiculo == ve.ID_Tipo_Vehiculo
                                        select new TransaccionDTO()
                                        {
                                            tipoVehiculo = ve.Tipo_Vehiculo1,
                                            patente = pat.Patente1,
                                            estado = est.Estado1,
                                            monto = trans.Precio,
                                            fecha = trans.Fecha
                                        });
                return transitoGenerado.ToList();
            }
        }

        public static bool UpdateValorVehiculo(string id, decimal nuevoValor)
        {
            using (var db = new TELEPEAJEEntities())
            {
                var t = db.Tipo_Vehiculo
                    .Where(x => x.ID_Tipo_Vehiculo.ToString() == id)
                    .First();
                t.Precio = nuevoValor;
                return db.SaveChanges() > 0;
            }
        }

        public static bool UpdateValorMulta(decimal nuevoValor)
        {
            using (var db = new TELEPEAJEEntities())
            {
                var t = db.Tipo_Vehiculo
                    .Where(x => x.Tipo_Vehiculo1 == "N/A")
                    .First();
                t.Precio = nuevoValor;
                return db.SaveChanges() > 0;
            }
        }

        public static object GetAllValoresMontos()
        {
            using (var db = new TELEPEAJEEntities())
            {
                var lista = (from t in db.Tipo_Vehiculo
                             select new 
                             {
                                 id = t.ID_Tipo_Vehiculo,
                                 tipo = t.Tipo_Vehiculo1,
                                 valor = t.Precio
                             })
                             .ToList();
                return lista;
            }
        }
        #endregion

    }
}
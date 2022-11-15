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
        public static List<TransaccionDTO> GetPatentesReconocidas()
        {
            return GetMultasPorEstado(CommonEnums.TipoEstadoEnum.Pago.ToString());
        }

        public static List<TransaccionDTO> GetPatentesNoReconocidas()
        {
            return GetMultasPorEstado(CommonEnums.TipoEstadoEnum.Multa.ToString());
        }
        #endregion
        #region Private methods

        private static List<TransaccionDTO> GetMultasPorEstado(string estado)
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
        #endregion

    }
}
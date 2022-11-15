using GeneralApi.Entities;
using GeneralApi.Models.Telepeaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Util;

namespace GeneralApi.Utils
{
    public class TransitoHelper
    {

        public static TransitoDTO GetTransitoGenerado()
        {
            using (var db = new TELEPEAJEEntities())
            {
                int _cantidadTransito = db.Transacciones.Count();                

                var _cantidadPorMulta = (from trans in db.Transacciones
                                         from est in db.Estadoes
                                         where trans.Estado.ID_Estado == est.ID_Estado
                                         && est.Estado1 == "Multa"
                                         select 1).Count();
                var _cantidadPorPago = _cantidadTransito - _cantidadPorMulta;

                return new TransitoDTO()
                {
                    cantidadTransito = _cantidadTransito,
                    cantidadPorMulta = _cantidadPorMulta,
                    cantidadPorPago = _cantidadPorPago
                };
            }

        }
    }
}
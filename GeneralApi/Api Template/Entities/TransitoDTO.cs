using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneralApi.Entities
{
    public class TransitoDTO
    {
        public int cantidadTransito;
        public int cantidadPorMulta;
        public int cantidadPorPago;
        public IList<object> cantidadPorTipoVehiculo;
    }
}
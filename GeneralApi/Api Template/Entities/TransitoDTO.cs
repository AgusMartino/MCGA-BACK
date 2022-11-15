using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneralApi.Entities
{
    public class TransaccionDTO
    {
        public string tipoVehiculo;
        public string patente;
        public string estado;
        public decimal monto;
        public DateTime fecha;

        public TransaccionDTO()
        {
        }
    }
}
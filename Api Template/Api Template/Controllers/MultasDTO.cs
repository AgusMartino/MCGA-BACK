using Api_Template.Models.Template;
using System;

namespace Api_Template.Controllers
{
    public class MultasDTO
    {
        public MultasDTO(Transacciones x)
        {
            id = x.ID_Transacciones.ToString();
            patente = x.Patente != null ? x.Patente.ID_Patente.ToString() : string.Empty;
            estado = x.Estado.ToString();
            fecha = x.Fecha;
            precio = x.Precio;
        }
        public MultasDTO() { }

        public string id { get; set; }
        public string patente { get; set; }
        public string estado { get; set; }
        public DateTime fecha { get; set; }
        public decimal precio { get; set; }
    }
}
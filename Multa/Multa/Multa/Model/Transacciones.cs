//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Multa.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transacciones
    {
        public System.Guid ID_Transacciones { get; set; }
        public System.Guid ID_Patente { get; set; }
        public System.Guid ID_Estado { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual Patente Patente { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pago.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patente()
        {
            this.Transacciones = new HashSet<Transacciones>();
        }
    
        public System.Guid ID_Patente { get; set; }
        public System.Guid ID_Tipo_Vehiculo { get; set; }
        public string Patente1 { get; set; }
        public bool Telepeaje { get; set; }
    
        public virtual Tipo_Vehiculo Tipo_Vehiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transacciones> Transacciones { get; set; }
    }
}

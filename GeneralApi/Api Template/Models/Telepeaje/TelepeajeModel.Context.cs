//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeneralApi.Models.Telepeaje
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TELEPEAJEEntities : DbContext
    {
        public TELEPEAJEEntities()
            : base("name=TELEPEAJEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<Estado_Servicios> Estado_Servicios { get; set; }
        public virtual DbSet<Patente> Patentes { get; set; }
        public virtual DbSet<Tipo_Vehiculo> Tipo_Vehiculo { get; set; }
        public virtual DbSet<Transaccione> Transacciones { get; set; }
    }
}

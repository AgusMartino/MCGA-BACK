using Pago.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pago.DLL
{
    public class DLL
    {
        #region Singleton
        private readonly static DLL _instance;
        public static DLL Current { get { return _instance; } }
        static DLL() { _instance = new DLL(); }
        private DLL()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void registrarPago(Transacciones transaccion)
        {
            using (var db = new TELEPEAJE())
            {
                db.Transacciones.Add(transaccion);
                db.SaveChanges();
            }
        }

        public Estado getEstado()
        {
            Estado estado = new Estado();
            using (var db = new TELEPEAJE())
            {
                estado = db.Estado.Where(x => x.Estado1 == "Pago").ToList().FirstOrDefault();
                return estado;
            }
        }

        public Tipo_Vehiculo GetTipo_Vehiculo(Guid guid)
        {
            Tipo_Vehiculo tipo_Vehiculo = new Tipo_Vehiculo();
            using(var db = new TELEPEAJE())
            {
                tipo_Vehiculo = db.Tipo_Vehiculo.Where(x=> x.ID_Tipo_Vehiculo == guid).ToList().FirstOrDefault();
            }
            return tipo_Vehiculo;
        }

        public Patente GetPatente(string mensaje)
        {
            Patente patente = new Patente();
            using(var db = new TELEPEAJE())
            {
                patente = db.Patente.Where(x=> x.Patente1 == mensaje).ToList().FirstOrDefault();
            }
            return patente;
        }
    }
}

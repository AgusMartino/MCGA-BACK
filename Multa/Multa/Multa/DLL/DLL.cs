using Multa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multa.DLL
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

        public void ingresarMulta(Transacciones transaccion)
        {
            using (var db = new TELEPEAJE())
            {
                db.Transacciones.Add(transaccion);
                db.SaveChanges();
            }
        }

        public Estado obtenerEstado()
        {
            Estado estado = new Estado(); 
            using (var db = new TELEPEAJE())
            {
                estado = db.Estado.Where(x => x.Estado1 == "Multa").ToList().FirstOrDefault();
                return estado;
            }
        }
        public Tipo_Vehiculo obtenerPrecio()
        {
            Tipo_Vehiculo tipo_Vehiculo = new Tipo_Vehiculo();
            using(var db = new TELEPEAJE())
            {
                tipo_Vehiculo = db.Tipo_Vehiculo.Where(x => x.Tipo_Vehiculo1 == "N/A").ToList().FirstOrDefault();
                return tipo_Vehiculo;
            }
        }
        public void registrarPatenteSinTelepeaje(Patente patente)
        {
            using (var db = new TELEPEAJE())
            {
                var coincidencia = db.Patente.Where(x => x.Patente1 == patente.Patente1);
                
                if(coincidencia.Count() == 0)
                {
                    db.Patente.Add(patente);
                    db.SaveChanges();
                } 
            }
        }

        public bool EstadoServicio()
        {
            bool estado = false;
            using (var db = new TELEPEAJE())
            {
                var state = db.Estado_Servicios.Where(x =>
                    x.Nombre_Microservicio == "Multa").ToList().FirstOrDefault();

                estado = state.Estado;
            }
            return estado;
        }
    }
}

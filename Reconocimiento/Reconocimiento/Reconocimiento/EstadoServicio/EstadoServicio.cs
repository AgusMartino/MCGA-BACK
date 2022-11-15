using Reconocimiento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconocimiento.EstadoServicio
{
    public class EstadoServicio
    {
        #region Singleton
        private readonly static EstadoServicio _instance;
        public static EstadoServicio Current { get { return _instance; } }
        static EstadoServicio() { _instance = new EstadoServicio(); }
        private EstadoServicio()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public bool Estado()
        {
            bool estado = false;
            using (var db = new TELEPEAJE())
            {
                var state = db.Estado_Servicios.Where(x =>
                    x.Nombre_Microservicio == "Reconocimiento").ToList().FirstOrDefault();

                estado = state.Estado;
            }
            return estado;
        }
    }
}

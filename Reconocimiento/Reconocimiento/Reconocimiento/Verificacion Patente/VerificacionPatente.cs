using Reconocimiento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconocimiento.Verificacion_Patente
{
    public class VerificacionPatente
    {
        #region Singleton
        private readonly static VerificacionPatente _instance;
        public static VerificacionPatente Current { get { return _instance; } }
        static VerificacionPatente() { _instance = new VerificacionPatente(); }
        private VerificacionPatente()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public bool Verificacion(string mensaje)
        {
            bool validador = false;
            using (var db = new TELEPEAJE())
            {
                var patente = db.Patente.Where(x =>
                    x.Patente1 == mensaje).ToList().FirstOrDefault();

                if (patente == null)
                {
                    validador = false;
                }
                else
                {
                    validador = true;
                }

                return validador;
            }
        }
    }
}

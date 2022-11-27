using Reconocimiento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconocimiento.Logger
{
    public class Logger
    {
        #region Singleton
        private readonly static Logger _instance;
        public static Logger Current { get { return _instance; } }
        static Logger() { _instance = new Logger(); }
        private Logger()
        {
            //Implent here the initialization of your singleton
        }
        #endregion
        public void Log(string Accion, string Patente)
        {
            string sistema = "Reconocimiento";
            Logs logs = new Logs();
            logs.ID_Log = Guid.NewGuid();
            logs.Sistema = sistema;
            logs.Accion = Accion;
            logs.Patente = Patente;
            logs.Fecha = DateTime.Now;

            using (var db = new TELEPEAJE())
            {
                db.Logs.Add(logs);
                db.SaveChanges();
            }
        }
    }
}

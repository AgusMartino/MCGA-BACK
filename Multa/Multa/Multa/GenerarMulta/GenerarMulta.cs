using Multa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multa.GenerarMulta
{
    public class GenerarMulta
    {
        #region Singleton
        private readonly static GenerarMulta _instance;
        public static GenerarMulta Current { get { return _instance; } }
        static GenerarMulta() { _instance = new GenerarMulta(); }
        private GenerarMulta()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void multa(string mensaje)
        {
            Patente patente = new Patente();
            Transacciones transaccion = new Transacciones();
            Estado estado = new Estado();
            Tipo_Vehiculo tipo_Vehiculo = new Tipo_Vehiculo();

            estado = DLL.DLL.Current.obtenerEstado();
            tipo_Vehiculo = DLL.DLL.Current.obtenerPrecio();

            //Busco patente
            patente = DLL.DLL.Current.GetPatente(mensaje);

            if(patente.ID_Patente == Guid.Empty)
            {
                //registro patente con multa
                patente.ID_Patente = Guid.NewGuid();
                patente.ID_Tipo_Vehiculo = tipo_Vehiculo.ID_Tipo_Vehiculo;
                patente.Telepeaje = false;
                patente.Patente1 = mensaje;
                DLL.DLL.Current.registrarPatenteSinTelepeaje(patente);
                Logger.Logger.Current.Log("Se registra patente no existente", mensaje);
            }
            //registro transaccion de multa
            transaccion.ID_Patente = patente.ID_Patente;
            transaccion.ID_Estado = estado.ID_Estado;
            transaccion.Fecha = DateTime.Now;
            transaccion.Precio = tipo_Vehiculo.Precio;
            transaccion.ID_Transacciones = Guid.NewGuid();
            DLL.DLL.Current.ingresarMulta(transaccion);
            Logger.Logger.Current.Log("Se registra multa a patente no subscripta", mensaje);
        }
    }
}

using Pago.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pago.GenerarPago
{
    public class GenerarPago
    {
        #region Singleton
        private readonly static GenerarPago _instance;
        public static GenerarPago Current { get { return _instance; } }
        static GenerarPago() { _instance = new GenerarPago(); }
        private GenerarPago()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void pago(string mensaje)
        {
            Patente patente = new Patente();
            patente = DLL.DLL.Current.GetPatente(mensaje);
            Tipo_Vehiculo tipo = new Tipo_Vehiculo();
            tipo = DLL.DLL.Current.GetTipo_Vehiculo(patente.ID_Tipo_Vehiculo);
            Estado estado = new Estado();
            estado = DLL.DLL.Current.getEstado();

            //registro de transaccion
            Transacciones transaccion = new Transacciones();
            transaccion.ID_Transacciones = Guid.NewGuid();
            transaccion.ID_Estado = estado.ID_Estado;
            transaccion.ID_Patente = patente.ID_Patente;
            transaccion.Fecha = DateTime.Now;
            transaccion.Precio = tipo.Precio;
            DLL.DLL.Current.registrarPago(transaccion);

        }
    }
}

using Api_Template.Controllers;
using Api_Template.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Template.Utils
{
    public class MultasManager
    {
        public static List<MultasDTO> GetAllMultas()
        {
            var entities = new TelepeajeEntities();
            var lista = new List<MultasDTO>();
            entities.Transacciones.ToList()
                .ForEach(tran => {
                    lista.Add(new MultasDTO(tran));
                });
            return lista;
        }

        public static MultasDTO GetOneMulta(string id)
        {
            var entities = new TelepeajeEntities();
            return new MultasDTO(
                entities.Transacciones.ToList()
                .Find(x => x.ID_Transacciones.ToString() == id)
                );
        }

        internal static object RemoveMulta(string id)
        {
            var entities = new TelepeajeEntities();
            var lista = entities.Transacciones;
            var obj = lista.ToList().Find(x => x.ID_Transacciones.ToString() == id);
            if (obj == null) return null;
            var removeExitoso = new MultasDTO(lista.Remove(obj));
            if (removeExitoso == null) return null;
            entities.SaveChanges();
            return removeExitoso;
        }
    }
}
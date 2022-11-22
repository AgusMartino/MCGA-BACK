using GeneralApi.Entities.Enums;
using GeneralApi.Models.Telepeaje;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GeneralApi.Utils
{
    public class ServiciosManager
    {
        public static bool EncenderServicioMultas()
        {
            return EncenderOApagarServicio(CommonEnums.TipoServiciosEnum.Multa, true);
        }
        public static bool ApagarServicioMultas()
        {
            return EncenderOApagarServicio(CommonEnums.TipoServiciosEnum.Multa, false);
        }

        public static bool EncenderServicioPagos()
        {
            return EncenderOApagarServicio(CommonEnums.TipoServiciosEnum.Pago, true);
        }
        public static bool ApagarServicioPagos()
        {
            return EncenderOApagarServicio(CommonEnums.TipoServiciosEnum.Pago, false);
        }

        public static bool EncenderServicioReconocimiento()
        {
            return EncenderOApagarServicio(CommonEnums.TipoServiciosEnum.Reconocimiento, true);
        }
        public static bool ApagarServicioReconocimiento()
        {
            return EncenderOApagarServicio(CommonEnums.TipoServiciosEnum.Reconocimiento, false);
        }

        private static bool EncenderOApagarServicio(CommonEnums.TipoServiciosEnum servicio, bool encender_o_apagar )
        {
            var servicioString = EnumHelper.GetDescriptionForEnumItem( servicio );

            using (var db = new TELEPEAJEEntities())
            {
                var s = db.Estado_Servicios
                    .Where(x => x.Nombre_Microservicio == servicioString)
                    .FirstOrDefault();
                s.Estado = encender_o_apagar;
                return db.SaveChanges() > 0;
            }
            return false;
        }
        
    }
}
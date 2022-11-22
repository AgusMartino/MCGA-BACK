using GeneralApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralApi.Controllers
{
    public class ServiciosController : ApiController
    {
        [HttpPut]
        public IHttpActionResult PutEncenderServicioMulta()
        {
            try
            {
                ServiciosManager.EncenderServicioMultas();
                return Ok(new { msg = "Servicio de multas encendido exitosamente!" });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult PutApagarServicioMulta()
        {
            try
            {
                ServiciosManager.ApagarServicioMultas();
                return Ok(new { msg = "Servicio de multas apagado exitosamente!" });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult PutEncenderServicioPagos()
        {
            try
            {
                ServiciosManager.EncenderServicioPagos();
                return Ok(new { msg = "Servicio de pagos encendido exitosamente!" });               
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult PutApagarServicioPagos()
        {
            try
            {
                ServiciosManager.ApagarServicioPagos();
                return Ok(new { msg = "Servicio de pagos apagado exitosamente!" });

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult PutEncenderServicioReconocimiento()
        {
            try
            {
                ServiciosManager.EncenderServicioReconocimiento();
                return Ok(new { msg = "Servicio de reconocimiento encendido exitosamente!" });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult PutApagarServicioReconocimiento()
        {
            try
            {
                ServiciosManager.ApagarServicioReconocimiento();
                return Ok(new { msg = "Servicio de reconocimiento apagado exitosamente!" });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
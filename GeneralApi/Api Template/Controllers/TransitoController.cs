using GeneralApi.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace GeneralApi.Controllers
{
    public class TransitoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetTransitoTotal()
        {
            try
            {
                var objTransito = TransitoManager.GetTransitoGenerado();
                if (objTransito == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(objTransito);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetPagosEmitidos()
        {
            try
            {
                var patentesReconocidas = TransitoManager.GetPagosEmitidos();
                if (patentesReconocidas == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(patentesReconocidas);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        public IHttpActionResult GetMultasEmitidas()
        {
            try
            {
                var patentesNoReconocidas = TransitoManager.GetMultasEmitidas();
                if (patentesNoReconocidas == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(patentesNoReconocidas);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        public IHttpActionResult GetTotalFacturado()
        {
            try
            {
                var totalFacturado = TransitoManager.GetTotalFacturado();
                if (totalFacturado == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(totalFacturado);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetCantidadVehiculosNoReconocidos()
        {
            try
            {
                var totalNoReconocidos = TransitoManager.GetCantidadVehiculosNoReconocidos();
                if (totalNoReconocidos == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(totalNoReconocidos);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        public IHttpActionResult GetCantidadVehiculosReconocidos()
        {
            try
            {
                var totalReconocidos = TransitoManager.GetCantidadVehiculosReconocidos();
                if (totalReconocidos == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(totalReconocidos);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
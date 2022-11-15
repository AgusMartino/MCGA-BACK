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
        public IHttpActionResult GetPatentesReconocidas()
        {
            try
            {
                var objTransito = TransitoManager.GetPatentesReconocidas();
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
        public IHttpActionResult GetPatentesNoReconocidas()
        {
            try
            {
                var objTransito = TransitoManager.GetPatentesNoReconocidas();
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

    }
}

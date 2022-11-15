using GeneralApi.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace GeneralApi.Controllers
{
    public class TransitoController : ApiController
    {
       [HttpGet]
       public IHttpActionResult GetTransitoTotal()
       {
            try
            {
                var objTransito = TransitoHelper.GetTransitoGenerado();
                if (objTransito == null)
                {
                    return BadRequest("No se pudo retornar la información del transito!");
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

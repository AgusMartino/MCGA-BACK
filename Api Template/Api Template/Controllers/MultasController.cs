using Api_Template.Contracts;
using Api_Template.Models.Template;
using Api_Template.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Api_Template.Utils;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;

namespace Api_Template.Controllers
{
    public class MultasController : ApiController
    {
        private int i = 0;
        public void Add(MultasDTO obj)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult GetAll()
        {
            var lista = MultasManager.GetAllMultas();
            if (lista == null) return NotFound();
            return Ok(lista);
        }
        [HttpPost]
        public IHttpActionResult GetOne([FromBody] string id)
        {
            var obj = MultasManager.GetOneMulta(id);
            if (obj == null) return NotFound();            
            return Ok(obj);
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] string id)
        {
            var obj = MultasManager.RemoveMulta(id);
            if (obj == null) return NotFound();
            return Ok(obj);
        }

        public void Update(Transacciones obj)
        {
            throw new NotImplementedException();
        }
    }
}
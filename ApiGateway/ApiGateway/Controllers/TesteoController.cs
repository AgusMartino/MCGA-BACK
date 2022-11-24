using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Results;
using ApiGateway.Utils;
using Newtonsoft.Json;
using RestSharp;

namespace ApiGateway.Controllers
{
    public class TesteoController : ApiController
    {
        #region Singleton
        private readonly static TesteoController _instance;
        public static TesteoController Current { get { return _instance; } }
        static TesteoController() { _instance = new TesteoController(); }
        private TesteoController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        Random random = new Random();

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new Persona() { Nombre = "Pablo", Edad = random.Next(18, 60) });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        public IHttpActionResult GetFiltered(string filtro)
        {
            try
            {
                var get = Get();
                var result = get as OkNegotiatedContentResult<Persona>;
                var persona = result.Content;
                return Ok($"(filtrado por '{filtro}') {persona}");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        public IHttpActionResult Procesar(string a_procesar, string pro2)
        {
            try
            {
                var controller = this.GetType().Name.Replace("Controller","");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { a_procesar, pro2 };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Get, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Procesar2([FromBody] string a_procesar)
        {
            try
            {
                return Ok($"(procesado 2) {a_procesar}");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        class Persona
        {
            public string Nombre;
            public int Edad;

            public override string ToString()
            {
                return $"Nombre: {Nombre}, Edad: {Edad}";
            }
        }
    }
}

using ApiGateway.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace ApiGateway.Controllers
{
    public class ServiciosController : ApiController
    {
        [HttpPut]
        public IHttpActionResult PutEncenderServicioMulta()
        {
            try
            {
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Put, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
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
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Put, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
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
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Put, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
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
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Put, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
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
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Put, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
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
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Put, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        public IHttpActionResult GetEstadoServicios()
        {
            try
            {
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Put, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
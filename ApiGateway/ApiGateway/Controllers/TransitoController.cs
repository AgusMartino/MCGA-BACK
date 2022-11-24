using ApiGateway.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace ApiGateway.Controllers
{
    public class TransitoController : ApiController
    {
        #region Get Endpoints
        [HttpGet]
        public IHttpActionResult GetTransitoTotal()
        {
            try
            {


                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Get, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
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
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Get, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
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
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Get, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
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
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Get, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
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
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Get, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
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
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Get, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        public IHttpActionResult GetAllMontosDeVehiculosYMulta()
        {
            try
            {
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Get, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion

        #region Put Endpoints

        [Microsoft.AspNetCore.Mvc.HttpPut("{id:string}")]
        public IHttpActionResult PutValorTipoVehiculo(string idTipoVehiculo, decimal nuevoValor)
        {
            try
            {
                var controller = this.GetType().Name.Replace("Controller", "");
                var method_name = MethodBase.GetCurrentMethod().Name;
                string[] method_params_values = { idTipoVehiculo, nuevoValor.ToString() };
                string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Put, controller, method_name, method_params_names, method_params_values);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        public IHttpActionResult PutValorMulta(decimal nuevoValor)
        {
            try
            {
                try
                {
                    var controller = this.GetType().Name.Replace("Controller", "");
                    var method_name = MethodBase.GetCurrentMethod().Name;
                    string[] method_params_values = { nuevoValor.ToString()};
                    string[] method_params_names = MethodBase.GetCurrentMethod().GetParameters().Select(x => x.Name).ToArray();
                    var resp = GatewayService.Current.ParseRequest(RestSharp.Method.Put, controller, method_name, method_params_names, method_params_values);

                    return Ok(resp);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        #endregion
    }
}
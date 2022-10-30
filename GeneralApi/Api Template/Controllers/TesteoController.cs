using System;
using System.Web.Http;
using System.Web.Http.Results;
using GeneralApi.Utils;
using GeneralApi.Entities.Exceptions;

namespace GeneralApi.Controllers
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

        [HttpGet]
        public IHttpActionResult GetX()
        {
            try
            {
                return Ok(TesteoManager.Current.GetX());
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        public IHttpActionResult Procesar(string a_procesar)
        {
            try
            {
                TesteoManager.Current.Procesar(a_procesar);
                return Ok($"procesado {a_procesar}");
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}

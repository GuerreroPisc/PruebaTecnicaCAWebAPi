using log4net;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using WebApi.Business.Contratos;
using WebApi.Entities;
using WebApi.Util;

namespace WebApi.Controllers
{
    [RoutePrefix("api/maestro")]
    public class MaestroController : ApiController
    {
        private readonly ILog log = LogManager.GetLogger(typeof(MaestroController));
        private IMaestroBO _maestroBO;
        public MaestroController(IMaestroBO maestroBO)
        {
            _maestroBO = maestroBO;
        }

        [HttpGet]
        [Route("listado")]
        [Authorize]
        public HttpResponseMessage GetListadoMaestro()
        {
            try
            {
                ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
                var validToken = HelperToken.LeerToken(principal);
                if (validToken.codigo != 1)
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized,
                        new MensajeHttpResponse() { Message = "No se pudo validar el token." });
                }
                var id_usuario = User.Identity.GetUserName();
                var respuesta = _maestroBO.GetListaMaestro(id_usuario);
                if (respuesta != null)
                {

                    if (respuesta.codigoRes == HttpStatusCode.OK)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new { Message = respuesta.mensajeRes, data = respuesta.datosSede });
                    }
                    else if (respuesta.codigoRes == HttpStatusCode.NoContent)
                    {
                        return Request.CreateResponse(HttpStatusCode.NoContent);
                    }
                    return Request.CreateResponse(respuesta.codigoRes,
                        new { Message = respuesta.mensajeRes });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,
                        new { Message = "Error interno al obtener respuesta." });
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                        new { Message = "Error interno en el servicio de listar maestro." });
            }
        }
    }
}
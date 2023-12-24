using log4net;
using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WebApi.Business.Contratos;
using WebApi.Entities;
using WebApi.Entities.Sede;
using WebApi.Util;

namespace WebApi.Controllers
{
    [RoutePrefix("api/sede")]
    public class SedeController : ApiController
    {
        private readonly ILog log = LogManager.GetLogger(typeof(SedeController));
        private ISedeBO _sedeBO;
        public SedeController(ISedeBO sedeBO)
        {
            _sedeBO = sedeBO;
        }

        [HttpGet]
        [Route("listado")]
        [Authorize]
        public HttpResponseMessage GetListadoSede(string nombre_sede)
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
                var respuesta = _sedeBO.GetListaSedes(nombre_sede, id_usuario);
                if (respuesta != null)
                {

                    if (respuesta.codigoRes == HttpStatusCode.OK)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new { Message = respuesta.mensajeRes, data = respuesta.datos });
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
                        new { Message = "Error interno en el servicio de listar sedes." });
            }
        }

        [HttpGet]
        [Route("detalle")]
        [Authorize]
        public HttpResponseMessage GetDetalleSede(int id_sede)
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
                var respuesta = _sedeBO.GetDetalleSede(id_sede, id_usuario);
                if (respuesta != null)
                {

                    if (respuesta.codigoRes == HttpStatusCode.OK)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new { Message = respuesta.mensajeRes, data = respuesta.datos });
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
                        new { Message = "Error interno en el servicio de detalle sede." });
            }
        }

        [HttpPut]
        [Route("editar")]
        [Authorize]
        public HttpResponseMessage PutEditarSede(int id_sede, EditarSedeRequest datos)
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
                var respuesta = _sedeBO.PutEditarSede(id_sede, datos, id_usuario);
                if (respuesta != null)
                {

                    if (respuesta.codigoRes == HttpStatusCode.OK)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new { Message = respuesta.mensajeRes });
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
                        new { Message = "Error interno en el servicio de edición." });
            }
        }

        [HttpPost]
        [Route("crear")]
        [Authorize]
        public HttpResponseMessage PostCrearSede(CrearSedeRequest datos)
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
                var respuesta = _sedeBO.PostCrearSede(datos, id_usuario);
                if (respuesta != null)
                {

                    if (respuesta.codigoRes == HttpStatusCode.Created)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created,
                            new { Message = respuesta.mensajeRes, respuesta.id_sede });
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
                        new { Message = "Error interno en el servicio de crear sede." });
            }
        }
             
        [HttpDelete]
        [Authorize]
        [Route("eliminar")]
        public HttpResponseMessage DeleteSede(int id_sede)
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
                var respuesta = _sedeBO.DeleteSede(id_sede, id_usuario);
                if (respuesta != null)
                {

                    if (respuesta.codigoRes == HttpStatusCode.OK)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new { Message = respuesta.mensajeRes });
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
                        new { Message = "Error interno en el servicio de eliminación." });
            }
        }
    }
}


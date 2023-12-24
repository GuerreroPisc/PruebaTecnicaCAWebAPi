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
using WebApi.Entities.ComplejoPolideportivo;
using WebApi.Util;

namespace WebApi.Controllers
{
    [RoutePrefix("api/complejo/polideportivo")]
    public class ComplejoPolideportivoController : ApiController
    {
        private readonly ILog log = LogManager.GetLogger(typeof(SedeController));
        private IComplejoPolideportivoBO _ComplejoPolideportivoBO;
        public ComplejoPolideportivoController(IComplejoPolideportivoBO ComplejoPolideportivoBO)
        {
            _ComplejoPolideportivoBO = ComplejoPolideportivoBO;
        }

        [HttpGet]
        [Route("listado")]
        [Authorize]
        public HttpResponseMessage GetListaComplejoPolideportivo(string nombre_complejoPoli, int id_sede )
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
                var respuesta = _ComplejoPolideportivoBO.GetListaComplejoPolideportivo(nombre_complejoPoli, id_sede, id_usuario);
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
                        new { Message = "Error interno en el servicio de listar complejos deportivos." });
            }
        }

        [HttpGet]
        [Route("detalle")]
        [Authorize]
        public HttpResponseMessage GetDetalleComplejoPolideportivo(int id_complejo_polideportivo)
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
                var respuesta = _ComplejoPolideportivoBO.GetDetalleComplejoPolideportivo(id_complejo_polideportivo, id_usuario);
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
                        new { Message = "Error interno en el servicio de detalle complejo polideportivo." });
            }
        }

        [HttpPut]
        [Route("editar")]
        [Authorize]
        public HttpResponseMessage PutEditarComplejoPolideportivo(int id_complejo_polideportivo, EditarComplejoPolideportivoRequest datos)
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
                var respuesta = _ComplejoPolideportivoBO.PutEditarComplejoPolideportivo(id_complejo_polideportivo, datos, id_usuario);
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
        public HttpResponseMessage PostCrearComplejoPolideportivo(CrearComplejoPolideportivoRequest datos)
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
                var respuesta = _ComplejoPolideportivoBO.PostCrearComplejoPolideportivo(datos, id_usuario);
                if (respuesta != null)
                {

                    if (respuesta.codigoRes == HttpStatusCode.Created)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created,
                            new { Message = respuesta.mensajeRes, respuesta.id_complejo_poli });
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
                        new { Message = "Error interno en el servicio de crear complejo deportivo." });
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("eliminar")]
        public HttpResponseMessage DeleteComplejoPolideportivo(int id_complejo_deportivo)
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
                var respuesta = _ComplejoPolideportivoBO.DeleteComplejoPolideportivo(id_complejo_deportivo, id_usuario);
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

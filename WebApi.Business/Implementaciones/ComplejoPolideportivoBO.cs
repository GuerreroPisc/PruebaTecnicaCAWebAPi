using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApi.Business.Contratos;
using WebApi.DataAccess.Contratos;
using WebApi.Entities.ComplejoPolideportivo;

namespace WebApi.Business.Implementaciones
{
    public class ComplejoPolideportivoBO : IComplejoPolideportivoBO
    {
        private readonly ILog log = LogManager.GetLogger(typeof(ComplejoPolideportivoBO));
        private readonly IComplejoPolideportivoDO _ComplejoPolideportivoDO;
        public ComplejoPolideportivoBO(IComplejoPolideportivoDO ComplejoPolideportivoDO)
        {
            _ComplejoPolideportivoDO = ComplejoPolideportivoDO;
        }

        public ListadoComplejoPolideportivo GetListaComplejoPolideportivo(string nombre_ComplejoPolideportivo,int id_sede, string id_usuario)
        {
            try
            {
                var datos = _ComplejoPolideportivoDO.GetListaComplejoPolideportivo(nombre_ComplejoPolideportivo, id_sede, id_usuario);
                if (datos.codigoRes != HttpStatusCode.OK)
                {
                    return new ListadoComplejoPolideportivo()
                    {
                        codigoRes = datos.codigoRes,
                        mensajeRes = datos.mensajeRes
                    };
                }
                if (datos.datos == null || datos.datos.Count <= 0)
                {
                    return new ListadoComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.BadRequest,
                        mensajeRes = "No se obtuvieron el listado de las ComplejoPolideportivos"
                    };
                }
                return new ListadoComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.OK,
                    mensajeRes = "Datos obtenidos correctamente.",
                    datos = datos.datos
                };

            }
            catch (Exception ex)
            {
                log.Error($"ComplejoPolideportivoBO -> GetListaComplejoPolideportivos. Mensaje al cliente: Error interno en el servicio listar ComplejoPolideportivos." + "Detalle error: " + JsonConvert.SerializeObject(ex));
                return new ListadoComplejoPolideportivo()
                {

                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error Interno al obtener respuesta de servicio listar ComplejoPolideportivos."
                };
            }
        }

        public DetalleComplejoPolideportivo GetDetalleComplejoPolideportivo(int id, string id_usuario)
        {
            try
            {
                var datos = _ComplejoPolideportivoDO.GetDetalleComplejoPolideportivo(id, id_usuario);
                if (datos.codigoRes != HttpStatusCode.OK)
                {
                    return new DetalleComplejoPolideportivo()
                    {
                        codigoRes = datos.codigoRes,
                        mensajeRes = datos.mensajeRes
                    };
                }
                if (datos.datos == null)
                {
                    return new DetalleComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.BadRequest,
                        mensajeRes = "No se obtuvieron el listado de las ComplejoPolideportivos"
                    };
                }
                return new DetalleComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.OK,
                    mensajeRes = "Datos obtenidos correctamente.",
                    datos = datos.datos
                };

            }
            catch (Exception ex)
            {
                log.Error($"ComplejoPolideportivoBO -> GetDetalleComplejoPolideportivo. Mensaje al cliente: Error interno en el servicio detalle ComplejoPolideportivo." + "Detalle error: " + JsonConvert.SerializeObject(ex));
                return new DetalleComplejoPolideportivo()
                {

                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error Interno al obtener respuesta de servicio listar ComplejoPolideportivos."
                };
            }
        }

        public EditarComplejoPolideportivo PutEditarComplejoPolideportivo(int id_ComplejoPolideportivo, EditarComplejoPolideportivoRequest data, string id_usuario)
        {
            try
            {
                var datos = _ComplejoPolideportivoDO.PutEditarComplejoPolideportivo(id_ComplejoPolideportivo, data, id_usuario);
                if (datos.codigoRes != HttpStatusCode.OK)
                {
                    return new EditarComplejoPolideportivo()
                    {
                        codigoRes = datos.codigoRes,
                        mensajeRes = datos.mensajeRes
                    };
                }
                if (datos == null)
                {
                    return new EditarComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.BadRequest,
                        mensajeRes = "No se obtuvieron el listado de las ComplejoPolideportivos"
                    };
                }
                return new EditarComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.OK,
                    mensajeRes = "Datos obtenidos correctamente."
                };

            }
            catch (Exception ex)
            {
                log.Error($"ComplejoPolideportivoBO -> PutEditarComplejoPolideportivo. Mensaje al cliente: Error interno en el servicio editar ComplejoPolideportivo." + "Detalle error: " + JsonConvert.SerializeObject(ex));
                return new EditarComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error Interno al obtener respuesta de servicio editar ComplejoPolideportivos."
                };
            }
        }

        public CrearComplejoPolideportivo PostCrearComplejoPolideportivo(CrearComplejoPolideportivoRequest data, string id_usuario)
        {
            try
            {
                var datos = _ComplejoPolideportivoDO.PostCrearComplejoPolideportivo(data, id_usuario);
                if (datos.codigoRes != HttpStatusCode.Created)
                {
                    return new CrearComplejoPolideportivo()
                    {
                        codigoRes = datos.codigoRes,
                        mensajeRes = datos.mensajeRes
                    };
                }
                if (datos == null)
                {
                    return new CrearComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.BadRequest,
                        mensajeRes = "No se obtuvo una repuesta de la creación."
                    };
                }
                return new CrearComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.Created,
                    mensajeRes = "La ComplejoPolideportivo se creo correctamente.",
                    id_complejo_poli = datos.id_complejo_poli
                };

            }
            catch (Exception ex)
            {
                log.Error($"ComplejoPolideportivoBO -> PostCrearComplejoPolideportivo. Mensaje al cliente: Error interno en el servicio crear ComplejoPolideportivo." + "Detalle error: " + JsonConvert.SerializeObject(ex));
                return new CrearComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error Interno al obtener respuesta de servicio crear ComplejoPolideportivos."
                };
            }
        }

        public EliminarComplejoPolideportivo DeleteComplejoPolideportivo(int id_ComplejoPolideportivo, string id_usuario)
        {
            try
            {
                var datos = _ComplejoPolideportivoDO.DeleteComplejoPolideportivo(id_ComplejoPolideportivo, id_usuario);
                if (datos.codigoRes != HttpStatusCode.OK)
                {
                    return new EliminarComplejoPolideportivo()
                    {
                        codigoRes = datos.codigoRes,
                        mensajeRes = datos.mensajeRes
                    };
                }
                if (datos == null)
                {
                    return new EliminarComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.BadRequest,
                        mensajeRes = "No se logro eliminar la ComplejoPolideportivo"
                    };
                }
                return new EliminarComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.OK,
                    mensajeRes = "ComplejoPolideportivo eliminada correctamente."
                };

            }
            catch (Exception ex)
            {
                log.Error($"ComplejoPolideportivoBO -> DeleteComplejoPolideportivo. Mensaje al cliente: Error interno en el servicio eliminar ComplejoPolideportivo." + "Detalle error: " + JsonConvert.SerializeObject(ex));
                return new EliminarComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error Interno al obtener respuesta de servicio eliminar ComplejoPolideportivos."
                };
            }
        }
    }
}

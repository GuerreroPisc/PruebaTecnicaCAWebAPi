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
using WebApi.Entities.Sede;

namespace WebApi.Business.Implementaciones
{
    public class SedeBO : ISedeBO
    {
        private readonly ILog log = LogManager.GetLogger(typeof(SedeBO));
        private readonly ISedeDO _sedeDO;
        public SedeBO(ISedeDO sedeDO)
        {
            _sedeDO = sedeDO;
        }        

        public ListadoSede GetListaSedes(string nombre_sede, string id_usuario)
        {
            try
            {
                var datos = _sedeDO.GetListaSedes(nombre_sede, id_usuario);
                if (datos.codigoRes != HttpStatusCode.OK)
                {
                    return new ListadoSede()
                    {
                        codigoRes = datos.codigoRes,
                        mensajeRes = datos.mensajeRes
                    };
                }
                if (datos.datos == null || datos.datos.Count <= 0)
                {
                    return new ListadoSede()
                    {
                        codigoRes = HttpStatusCode.BadRequest,
                        mensajeRes = "No se obtuvieron el listado de las sedes"
                    };
                }
                return new ListadoSede()
                {
                    codigoRes = HttpStatusCode.OK,
                    mensajeRes = "Datos obtenidos correctamente.",
                    datos = datos.datos
                };

            }
            catch (Exception ex)
            {
                log.Error($"SedeBO -> GetListaSedes. Mensaje al cliente: Error interno en el servicio listar sedes." + "Detalle error: " + JsonConvert.SerializeObject(ex));
                return new ListadoSede()
                {

                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error Interno al obtener respuesta de servicio listar sedes."
                };
            }
        }

        public DetalleSede GetDetalleSede(int id, string id_usuario)
        {
            try
            {
                var datos = _sedeDO.GetDetalleSede(id, id_usuario);
                if (datos.codigoRes != HttpStatusCode.OK)
                {
                    return new DetalleSede()
                    {
                        codigoRes = datos.codigoRes,
                        mensajeRes = datos.mensajeRes
                    };
                }
                if (datos.datos == null)
                {
                    return new DetalleSede()
                    {
                        codigoRes = HttpStatusCode.BadRequest,
                        mensajeRes = "No se obtuvieron el listado de las sedes"
                    };
                }
                return new DetalleSede()
                {
                    codigoRes = HttpStatusCode.OK,
                    mensajeRes = "Datos obtenidos correctamente.",
                    datos = datos.datos
                };

            }
            catch (Exception ex)
            {
                log.Error($"SedeBO -> GetDetalleSede. Mensaje al cliente: Error interno en el servicio detalle sede." + "Detalle error: " + JsonConvert.SerializeObject(ex));
                return new DetalleSede()
                {

                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error Interno al obtener respuesta de servicio listar sedes."
                };
            }
        }

        public EditarSede PutEditarSede(int id_sede, EditarSedeRequest data, string id_usuario)
        {
            try
            {
                var datos = _sedeDO.PutEditarSede(id_sede, data, id_usuario);
                if (datos.codigoRes != HttpStatusCode.OK)
                {
                    return new EditarSede()
                    {
                        codigoRes = datos.codigoRes,
                        mensajeRes = datos.mensajeRes
                    };
                }
                if (datos == null)
                {
                    return new EditarSede()
                    {
                        codigoRes = HttpStatusCode.BadRequest,
                        mensajeRes = "No se obtuvieron el listado de las sedes"
                    };
                }
                return new EditarSede()
                {
                    codigoRes = HttpStatusCode.OK,
                    mensajeRes = "Datos obtenidos correctamente."
                };

            }
            catch (Exception ex)
            {
                log.Error($"SedeBO -> PutEditarSede. Mensaje al cliente: Error interno en el servicio editar sede." + "Detalle error: " + JsonConvert.SerializeObject(ex));
                return new EditarSede()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error Interno al obtener respuesta de servicio editar sedes."
                };
            }
        }

        public CrearSede PostCrearSede(CrearSedeRequest data, string id_usuario)
        {
            try
            {
                var datos = _sedeDO.PostCrearSede(data, id_usuario);
                if (datos.codigoRes != HttpStatusCode.Created)
                {
                    return new CrearSede()
                    {
                        codigoRes = datos.codigoRes,
                        mensajeRes = datos.mensajeRes
                    };
                }
                if (datos == null)
                {
                    return new CrearSede()
                    {
                        codigoRes = HttpStatusCode.BadRequest,
                        mensajeRes = "No se obtuvo una repuesta de la creación."
                    };
                }
                return new CrearSede()
                {
                    codigoRes = HttpStatusCode.Created,
                    mensajeRes = "La sede se creo correctamente.",
                    id_sede = datos.id_sede
                };

            }
            catch (Exception ex)
            {
                log.Error($"SedeBO -> PostCrearSede. Mensaje al cliente: Error interno en el servicio crear sede." + "Detalle error: " + JsonConvert.SerializeObject(ex));
                return new CrearSede()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error Interno al obtener respuesta de servicio crear sedes."
                };
            }
        }

        public EliminarSede DeleteSede(int id_sede, string id_usuario)
        {
            try
            {
                var datos = _sedeDO.DeleteSede(id_sede, id_usuario);
                if (datos.codigoRes != HttpStatusCode.OK)
                {
                    return new EliminarSede()
                    {
                        codigoRes = datos.codigoRes,
                        mensajeRes = datos.mensajeRes
                    };
                }
                if (datos == null)
                {
                    return new EliminarSede()
                    {
                        codigoRes = HttpStatusCode.BadRequest,
                        mensajeRes = "No se logro eliminar la sede"
                    };
                }
                return new EliminarSede()
                {
                    codigoRes = HttpStatusCode.OK,
                    mensajeRes = "Sede eliminada correctamente."
                };

            }
            catch (Exception ex)
            {
                log.Error($"SedeBO -> DeleteSede. Mensaje al cliente: Error interno en el servicio eliminar sede." + "Detalle error: " + JsonConvert.SerializeObject(ex));
                return new EliminarSede()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error Interno al obtener respuesta de servicio eliminar sedes."
                };
            }
        }
    }
}

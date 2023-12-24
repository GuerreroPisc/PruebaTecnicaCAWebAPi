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
using WebApi.Entities.Maestro;

namespace WebApi.Business.Implementaciones
{
    public class MaestroBO : IMaestroBO
    {
        private readonly ILog log = LogManager.GetLogger(typeof(SedeBO));
        private readonly IMaestroDO _maestroDO;
        public MaestroBO(IMaestroDO maestroDO)
        {
            _maestroDO = maestroDO;
        }

        public ListadoMaestro GetListaMaestro(string id_usuario)
        {
            try
            {
                var datos = _maestroDO.GetListaMaestro(id_usuario);
                if (datos.codigoRes != HttpStatusCode.OK)
                {
                    return new ListadoMaestro()
                    {
                        codigoRes = datos.codigoRes,
                        mensajeRes = datos.mensajeRes
                    };
                }
                if (datos.datosSede == null || datos.datosSede.Count <= 0)
                {
                    return new ListadoMaestro()
                    {
                        codigoRes = HttpStatusCode.BadRequest,
                        mensajeRes = "No se obtuvieron el listado de maestros sede"
                    };
                }
                return new ListadoMaestro()
                {
                    codigoRes = HttpStatusCode.OK,
                    mensajeRes = "Datos obtenidos correctamente.",
                    datosSede = datos.datosSede
                };

            }
            catch (Exception ex)
            {
                log.Error($"MaestroBO -> GetListaMaestro. Mensaje al cliente: Error interno en el servicio listar maestros." + "Detalle error: " + JsonConvert.SerializeObject(ex));
                return new ListadoMaestro()
                {

                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error Interno al obtener respuesta de servicio listar maestros."
                };
            }
        }
    }
    }

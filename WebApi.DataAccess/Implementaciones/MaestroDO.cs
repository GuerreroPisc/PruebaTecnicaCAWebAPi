using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApi.DataAccess.Contratos;
using WebApi.DataAccess.Models;
using WebApi.Entities.EntitiesBD;
using WebApi.Entities.Maestro;

namespace WebApi.DataAccess.Implementaciones
{
    public class MaestroDO : IMaestroDO
    {
        public ListadoMaestro GetListaMaestro(string id_usuario)
        {
            try
            {
                var ctx = new OLIMPICAS_BD_CAEntities();

                var id_usuarioParameter = new SqlParameter("id_usuario", (object)id_usuario ?? DBNull.Value);

                var datosBusqueda = ctx.Database.SqlQuery<SP_MAESTRO_SEDE_Result>("SP_MAESTRO_SEDE " +
                                    "@id_usuario",
                                     id_usuarioParameter).ToList();

                if (datosBusqueda != null && datosBusqueda.Count > 0)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SP_MAESTRO_SEDE_Result, ItemMaestroSede>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var datosMapeados = mapper.Map<List<SP_MAESTRO_SEDE_Result>, List<ItemMaestroSede>>(datosBusqueda);

                    return new ListadoMaestro()
                    {
                        codigoRes = HttpStatusCode.OK,
                        mensajeRes = "Se obtuvieron los datos correctamente.",
                        datosSede = datosMapeados.ToList()
                    };
                }
                else
                {
                    return new ListadoMaestro()
                    {
                        codigoRes = HttpStatusCode.NoContent,
                        mensajeRes = "No se obtuvieron datos de maestro sede.",
                        datosSede = new List<ItemMaestroSede>()
                    };
                }
            }
            catch (Exception)
            {
                return new ListadoMaestro()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error al obtenerlos datos de maestro sede",
                    datosSede = new List<ItemMaestroSede>()
                };
            }
        }
    }
}

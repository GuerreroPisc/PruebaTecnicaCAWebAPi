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
using WebApi.Entities.ComplejoPolideportivo;
using WebApi.Entities.EntitiesBD;

namespace WebApi.DataAccess.Implementaciones
{
    public class ComplejoPolideportivoDO : IComplejoPolideportivoDO
    {
        public ListadoComplejoPolideportivo GetListaComplejoPolideportivo(string nombre_ComplejoPolideportivo, int id_sede, string id_usuario)
        {
            try
            {
                var ctx = new OLIMPICAS_BD_CAEntities();

                var id_sedeParameter = new SqlParameter("id_sede", (object)id_sede ?? DBNull.Value);
                var nombre_complejo_poliParameter = new SqlParameter("nombre_complejo_poli", (object)nombre_ComplejoPolideportivo ?? DBNull.Value);
                var id_usuarioParameter = new SqlParameter("id_usuario", (object)id_usuario ?? DBNull.Value);

                var datosBusqueda = ctx.Database.SqlQuery<SP_MAN_COMPLEJOPOLIDEPORTIVO_LISTADO_Result>("SP_MAN_COMPLEJOPOLIDEPORTIVO_LISTADO " +
                                    "@id_sede ,@nombre_complejo_poli, @id_usuario",
                                    id_sedeParameter, nombre_complejo_poliParameter, id_usuarioParameter).ToList();

                if (datosBusqueda != null && datosBusqueda.Count > 0)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SP_MAN_COMPLEJOPOLIDEPORTIVO_LISTADO_Result, ItemComplejoPolideportivo>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var datosMapeados = mapper.Map<List<SP_MAN_COMPLEJOPOLIDEPORTIVO_LISTADO_Result>, List<ItemComplejoPolideportivo>>(datosBusqueda);

                    return new ListadoComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.OK,
                        mensajeRes = "Se obtuvieron los datos correctamente.",
                        datos = datosMapeados.ToList()
                    };
                }
                else
                {
                    return new ListadoComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.NoContent,
                        mensajeRes = "No se obtuvieron datos.",
                        datos = new List<ItemComplejoPolideportivo>()
                    };
                }
            }
            catch (Exception ex)
            {
                return new ListadoComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error al obtenerlos datos",
                    datos = new List<ItemComplejoPolideportivo>()
                };
            }
        }

        public DetalleComplejoPolideportivo GetDetalleComplejoPolideportivo(int id_complejo_poli, string id_usuario)
        {
            try
            {
                var ctx = new OLIMPICAS_BD_CAEntities();

                var id_complejo_poliParameter = new SqlParameter("id_complejo_poli", (object)id_complejo_poli ?? DBNull.Value);
                var id_usuarioParameter = new SqlParameter("id_usuario", (object)id_usuario ?? DBNull.Value);

                var datosBusqueda = ctx.Database.SqlQuery<SP_MAN_COMPLEJOPOLIDEPORTIVO_DETALLE_Result>("SP_MAN_COMPLEJOPOLIDEPORTIVO_DETALLE " +
                                    "@id_complejo_poli, @id_usuario",
                                    id_complejo_poliParameter, id_usuarioParameter).FirstOrDefault();

                if (datosBusqueda != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SP_MAN_COMPLEJOPOLIDEPORTIVO_DETALLE_Result, ItemComplejoPolideportivoDetalle>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var datosMapeados = mapper.Map<SP_MAN_COMPLEJOPOLIDEPORTIVO_DETALLE_Result, ItemComplejoPolideportivoDetalle>(datosBusqueda);

                    return new DetalleComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.OK,
                        mensajeRes = "Se obtuvieron los datos correctamente.",
                        datos = datosMapeados
                    };
                }
                else
                {
                    return new DetalleComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.NoContent,
                        mensajeRes = "No se obtuvieron datos.",
                        datos = new ItemComplejoPolideportivoDetalle()
                    };
                }
            }
            catch (Exception)
            {
                return new DetalleComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error al obtenerlos datos",
                    datos = new ItemComplejoPolideportivoDetalle()
                };
            }
        }

        public EditarComplejoPolideportivo PutEditarComplejoPolideportivo(int id_complejo_poli, EditarComplejoPolideportivoRequest data, string id_usuario)
        {
            try
            {
                var ctx = new OLIMPICAS_BD_CAEntities();

                var id_complejo_poliParameter = new SqlParameter("id_complejo_poli", (object)id_complejo_poli ?? DBNull.Value);
                var id_usuarioParameter = new SqlParameter("id_usuario", (object)id_usuario ?? DBNull.Value);
                var nombre_complejo_poliParameter = new SqlParameter("nombre_complejo_poli", (object)data.nombre_complejo_poli ?? DBNull.Value);
                var id_sedeParameter = new SqlParameter("id_sede", (object)data.id_sede ?? DBNull.Value);
                var estadoParameter = new SqlParameter("estado", (object)data.estado ?? DBNull.Value);

                var datosBusqueda = ctx.Database.SqlQuery<SP_MAN_COMPLEJOPOLIDEPORTIVO_EDICION_Result>("SP_MAN_COMPLEJOPOLIDEPORTIVO_EDICION " +
                                    "@id_complejo_poli, @id_usuario,@nombre_complejo_poli, @id_sede, @estado",
                                    id_complejo_poliParameter, id_usuarioParameter, nombre_complejo_poliParameter, id_sedeParameter, estadoParameter).FirstOrDefault();

                if (datosBusqueda != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SP_MAN_COMPLEJOPOLIDEPORTIVO_EDICION_Result, EditarComplejoPolideportivoSP>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var datosMapeados = mapper.Map<SP_MAN_COMPLEJOPOLIDEPORTIVO_EDICION_Result, EditarComplejoPolideportivoSP>(datosBusqueda);

                    return new EditarComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.OK,
                        mensajeRes = "Se actualizo correctamente los datos."
                    };
                }
                else
                {
                    return new EditarComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.NoContent,
                        mensajeRes = "No se logro actualizar la sede."
                    };
                }
            }
            catch (Exception ex)
            {
                return new EditarComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error al editar la sede"
                };
            }
        }

        public CrearComplejoPolideportivo PostCrearComplejoPolideportivo(CrearComplejoPolideportivoRequest data, string id_usuario)
        {
            try
            {
                var ctx = new OLIMPICAS_BD_CAEntities();

                var id_usuarioParameter = new SqlParameter("id_usuario", (object)id_usuario ?? DBNull.Value);
                var nombre_complejo_poliParameter = new SqlParameter("nombre_complejo_poli", (object)data.nombre_complejo_poli ?? DBNull.Value);
                var id_sedeParameter = new SqlParameter("id_sede", (object)data.id_sede ?? DBNull.Value);
                var estadoParameter = new SqlParameter("estado", (object)data.estado ?? DBNull.Value);

                var datosBusqueda = ctx.Database.SqlQuery<SP_MAN_COMPLEJOPOLIDEPORTIVO_CREACION_Result>("SP_MAN_COMPLEJOPOLIDEPORTIVO_CREACION " +
                                    "@id_usuario, @nombre_complejo_poli, @id_sede, @estado",
                                     id_usuarioParameter, nombre_complejo_poliParameter, id_sedeParameter, estadoParameter).FirstOrDefault();

                if (datosBusqueda != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SP_MAN_COMPLEJOPOLIDEPORTIVO_CREACION_Result, CrearComplejoPolideportivoSP>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var datosMapeados = mapper.Map<SP_MAN_COMPLEJOPOLIDEPORTIVO_CREACION_Result, CrearComplejoPolideportivoSP>(datosBusqueda);

                    return new CrearComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.Created,
                        mensajeRes = "Se creo correctamente los datos.",
                        id_complejo_poli = datosBusqueda.id_complejo_poli
                    };
                }
                else
                {
                    return new CrearComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.NoContent,
                        mensajeRes = "No se logro crear la sede."
                    };
                }
            }
            catch (Exception ex)
            {
                return new CrearComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error al crear la sede"
                };
            }
        }

        public EliminarComplejoPolideportivo DeleteComplejoPolideportivo(int id_complejo_poli, string id_usuario)
        {
            try
            {
                var ctx = new OLIMPICAS_BD_CAEntities();

                var id_complejo_poliParameter = new SqlParameter("id_complejo_poli", (object)id_complejo_poli ?? DBNull.Value);
                var id_usuarioParameter = new SqlParameter("id_usuario", (object)id_usuario ?? DBNull.Value);

                var datosBusqueda = ctx.Database.SqlQuery<SP_MAN_COMPLEJOPOLIDEPORTIVO_ELIMINACION_Result>("SP_MAN_COMPLEJOPOLIDEPORTIVO_ELIMINACION " +
                                    "@id_complejo_poli, @id_usuario",
                                    id_complejo_poliParameter, id_usuarioParameter).FirstOrDefault();

                if (datosBusqueda != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SP_MAN_COMPLEJOPOLIDEPORTIVO_ELIMINACION_Result, EliminarComplejoPolideportivoSP>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var datosMapeados = mapper.Map<SP_MAN_COMPLEJOPOLIDEPORTIVO_ELIMINACION_Result, EliminarComplejoPolideportivoSP>(datosBusqueda);

                    return new EliminarComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.OK,
                        mensajeRes = "Se elimino la sede correctamente."
                    };
                }
                else
                {
                    return new EliminarComplejoPolideportivo()
                    {
                        codigoRes = HttpStatusCode.NoContent,
                        mensajeRes = "No logro eliminar la sede."
                    };
                }
            }
            catch (Exception)
            {
                return new EliminarComplejoPolideportivo()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error al eliminar la sede."
                };
            }
        }
    }
}

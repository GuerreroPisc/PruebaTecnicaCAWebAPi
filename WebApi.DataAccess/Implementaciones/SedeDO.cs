using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using WebApi.DataAccess.Contratos;
using WebApi.DataAccess.Models;
using WebApi.Entities.EntitiesBD;
using WebApi.Entities.Sede;

namespace WebApi.DataAccess.Implementaciones
{
    public class SedeDO : ISedeDO
    {        

        public ListadoSede GetListaSedes(string nombre_sede, string id_usuario)
        {
            try
            {
                var ctx = new OLIMPICAS_BD_CAEntities();

                var nombre_sedeParameter = new SqlParameter("nombre_sede", (object)nombre_sede ?? DBNull.Value);
                var id_usuarioParameter = new SqlParameter("id_usuario", (object)id_usuario ?? DBNull.Value);

                var datosBusqueda = ctx.Database.SqlQuery<SP_MAN_SEDE_LISTADO_Result>("SP_MAN_SEDE_LISTADO " +
                                    "@nombre_sede, @id_usuario",
                                    nombre_sedeParameter, id_usuarioParameter).ToList();

                if (datosBusqueda != null && datosBusqueda.Count > 0)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SP_MAN_SEDE_LISTADO_Result, ItemSede>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var datosMapeados = mapper.Map<List<SP_MAN_SEDE_LISTADO_Result>, List<ItemSede>>(datosBusqueda);

                    return new ListadoSede()
                    {
                        codigoRes = HttpStatusCode.OK,
                        mensajeRes = "Se obtuvieron los datos correctamente.",
                        datos = datosMapeados.ToList()
                    };
                }
                else
                {
                    return new ListadoSede()
                    {
                        codigoRes = HttpStatusCode.NoContent,
                        mensajeRes = "No se obtuvieron datos.",
                        datos = new List<ItemSede>()
                    };
                }
            }
            catch (Exception)
            {
                return new ListadoSede()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error al obtenerlos datos",
                    datos = new List<ItemSede>()
                };
            }
        }

        public DetalleSede GetDetalleSede(int id_sede, string id_usuario)
        {
            try
            {
                var ctx = new OLIMPICAS_BD_CAEntities();

                var id_sedeParameter = new SqlParameter("id_sede", (object)id_sede ?? DBNull.Value);
                var id_usuarioParameter = new SqlParameter("id_usuario", (object)id_usuario ?? DBNull.Value);

                var datosBusqueda = ctx.Database.SqlQuery<SP_MAN_SEDE_DETALLE_Result>("SP_MAN_SEDE_DETALLE " +
                                    "@id_sede, @id_usuario",
                                    id_sedeParameter, id_usuarioParameter).FirstOrDefault();

                if (datosBusqueda != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SP_MAN_SEDE_DETALLE_Result, ItemSedeDetalle>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var datosMapeados = mapper.Map<SP_MAN_SEDE_DETALLE_Result, ItemSedeDetalle>(datosBusqueda);

                    return new DetalleSede()
                    {
                        codigoRes = HttpStatusCode.OK,
                        mensajeRes = "Se obtuvieron los datos correctamente.",
                        datos = datosMapeados
                    };
                }
                else
                {
                    return new DetalleSede()
                    {
                        codigoRes = HttpStatusCode.NoContent,
                        mensajeRes = "No se obtuvieron datos.",
                        datos = new ItemSedeDetalle()
                    };
                }
            }
            catch (Exception)
            {
                return new DetalleSede()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error al obtenerlos datos",
                    datos = new ItemSedeDetalle()
                };
            }
        }

        public EditarSede PutEditarSede(int id_sede, EditarSedeRequest data, string id_usuario)
        {
            try
            {
                var ctx = new OLIMPICAS_BD_CAEntities();

                var id_sedeParameter = new SqlParameter("id_sede", (object)id_sede ?? DBNull.Value);
                var id_usuarioParameter = new SqlParameter("id_usuario", (object)id_usuario ?? DBNull.Value);
                var nombre_sedeParameter = new SqlParameter("nombre_sede", (object)data.nombre_sede ?? DBNull.Value);
                var numero_complejosParameter = new SqlParameter("numero_complejos", (object)data.numero_complejos ?? DBNull.Value);
                var presupuestoParameter = new SqlParameter("presupuesto", (object)data.presupuesto ?? DBNull.Value);
                var estadoParameter = new SqlParameter("estado", (object)data.estado ?? DBNull.Value);

                var datosBusqueda = ctx.Database.SqlQuery<SP_MAN_SEDE_EDICION_Result>("SP_MAN_SEDE_EDICION " +
                                    "@id_sede, @id_usuario,@nombre_sede, @numero_complejos,@presupuesto, @estado",
                                    id_sedeParameter, id_usuarioParameter, nombre_sedeParameter, numero_complejosParameter, presupuestoParameter, estadoParameter).FirstOrDefault();

                if (datosBusqueda != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SP_MAN_SEDE_EDICION_Result, EditarSedeSP>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var datosMapeados = mapper.Map<SP_MAN_SEDE_EDICION_Result, EditarSedeSP>(datosBusqueda);

                    return new EditarSede()
                    {
                        codigoRes = HttpStatusCode.OK,
                        mensajeRes = "Se actualizo correctamente los datos."
                    };
                }
                else
                {
                    return new EditarSede()
                    {
                        codigoRes = HttpStatusCode.NoContent,
                        mensajeRes = "No se logro actualizar la sede."
                    };
                }
            }
            catch (Exception ex)
            {
                return new EditarSede()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error al editar la sede"
                };
            }
        }

        public CrearSede PostCrearSede(CrearSedeRequest data, string id_usuario)
        {
            try
            {
                var ctx = new OLIMPICAS_BD_CAEntities();

                var id_usuarioParameter = new SqlParameter("id_usuario", (object)id_usuario ?? DBNull.Value);
                var nombre_sedeParameter = new SqlParameter("nombre_sede", (object)data.nombre_sede ?? DBNull.Value);
                var numero_complejosParameter = new SqlParameter("numero_complejos", (object)data.numero_complejos ?? DBNull.Value);
                var presupuestoParameter = new SqlParameter("presupuesto", (object)data.presupuesto ?? DBNull.Value);
                var estadoParameter = new SqlParameter("estado", (object)data.estado ?? DBNull.Value);

                var datosBusqueda = ctx.Database.SqlQuery<SP_MAN_SEDE_CREACION_Result>("SP_MAN_SEDE_CREACION " +
                                    "@id_usuario, @nombre_sede, @numero_complejos, @presupuesto, @estado",
                                     id_usuarioParameter, nombre_sedeParameter, numero_complejosParameter, presupuestoParameter, estadoParameter).FirstOrDefault();

                if (datosBusqueda != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SP_MAN_SEDE_CREACION_Result, CrearSedeSP>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var datosMapeados = mapper.Map<SP_MAN_SEDE_CREACION_Result, CrearSedeSP>(datosBusqueda);

                    return new CrearSede()
                    {
                        codigoRes = HttpStatusCode.Created,
                        mensajeRes = "Se creo correctamente los datos.",
                        id_sede = datosBusqueda.id_sede
                    };
                }
                else
                {
                    return new CrearSede()
                    {
                        codigoRes = HttpStatusCode.NoContent,
                        mensajeRes = "No se logro crear la sede."
                    };
                }
            }
            catch (Exception ex)
            {
                return new CrearSede()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error al crear la sede"
                };
            }
        }

        public EliminarSede DeleteSede(int id_sede, string id_usuario)
        {
            try
            {
                var ctx = new OLIMPICAS_BD_CAEntities();

                var id_sedeParameter = new SqlParameter("id_sede", (object)id_sede ?? DBNull.Value);
                var id_usuarioParameter = new SqlParameter("id_usuario", (object)id_usuario ?? DBNull.Value);

                var datosBusqueda = ctx.Database.SqlQuery<SP_MAN_SEDE_ELIMINACION_Result>("SP_MAN_SEDE_ELIMINACION " +
                                    "@id_sede, @id_usuario",
                                    id_sedeParameter, id_usuarioParameter).FirstOrDefault();

                if (datosBusqueda != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SP_MAN_SEDE_ELIMINACION_Result, EliminarSedeSP>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var datosMapeados = mapper.Map<SP_MAN_SEDE_ELIMINACION_Result, EliminarSedeSP>(datosBusqueda);

                    return new EliminarSede()
                    {
                        codigoRes = HttpStatusCode.OK,
                        mensajeRes = "Se elimino la sede correctamente."
                    };
                }
                else
                {
                    return new EliminarSede()
                    {
                        codigoRes = HttpStatusCode.NoContent,
                        mensajeRes = "No logro eliminar la sede."
                    };
                }
            }
            catch (Exception)
            {
                return new EliminarSede()
                {
                    codigoRes = HttpStatusCode.InternalServerError,
                    mensajeRes = "Error al eliminar la sede."
                };
            }
        }
    }
}

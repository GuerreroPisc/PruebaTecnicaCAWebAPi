using WebApi.Entities.Sede;

namespace WebApi.DataAccess.Contratos
{
    public interface ISedeDO
    {
        ListadoSede GetListaSedes(string nombre_sede, string id_usuario);
        DetalleSede GetDetalleSede(int id_sede, string id_usuario);
        EditarSede PutEditarSede(int id_sede, EditarSedeRequest data, string id_usuario);
        CrearSede PostCrearSede(CrearSedeRequest data, string id_usuario);
        EliminarSede DeleteSede(int id_sede, string id_usuario);
    }
}

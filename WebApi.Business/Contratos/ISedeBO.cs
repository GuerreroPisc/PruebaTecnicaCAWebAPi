using WebApi.Entities.Sede;

namespace WebApi.Business.Contratos
{
    public interface ISedeBO
    {
        ListadoSede GetListaSedes(string nombre_sede, string id_usuario);
        DetalleSede GetDetalleSede(int id_sede, string id_usuario);
        EditarSede PutEditarSede(int id_sede, EditarSedeRequest datos, string id_usuario);
        CrearSede PostCrearSede(CrearSedeRequest datos, string id_usuario); 
        EliminarSede DeleteSede(int id_sede, string id_usuario);

    }
}

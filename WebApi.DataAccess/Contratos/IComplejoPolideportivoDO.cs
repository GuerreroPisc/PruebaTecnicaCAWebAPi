using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities.ComplejoPolideportivo;

namespace WebApi.DataAccess.Contratos
{
    public interface IComplejoPolideportivoDO
    {
        ListadoComplejoPolideportivo GetListaComplejoPolideportivo(string nombre_ComplejoPolideportivo, int id_sede, string id_usuario);
        DetalleComplejoPolideportivo GetDetalleComplejoPolideportivo(int id_ComplejoPolideportivo, string id_usuario);
        EditarComplejoPolideportivo PutEditarComplejoPolideportivo(int id_ComplejoPolideportivo, EditarComplejoPolideportivoRequest datos, string id_usuario);
        CrearComplejoPolideportivo PostCrearComplejoPolideportivo(CrearComplejoPolideportivoRequest datos, string id_usuario);
        EliminarComplejoPolideportivo DeleteComplejoPolideportivo(int id_ComplejoPolideportivo, string id_usuario);
    }
}

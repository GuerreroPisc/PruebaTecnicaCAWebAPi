using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities.Maestro;

namespace WebApi.DataAccess.Contratos
{
    public interface IMaestroDO
    {
        ListadoMaestro GetListaMaestro(string id_usuario);
    }
}

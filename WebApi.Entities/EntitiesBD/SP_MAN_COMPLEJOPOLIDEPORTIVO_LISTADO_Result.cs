using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities.EntitiesBD
{
    public class SP_MAN_COMPLEJOPOLIDEPORTIVO_LISTADO_Result
    {
        public int id_complejo_poli { get; set; }
        public string nombre_sede { get; set; }
        public string cod_complejo_poli { get; set; }
        public string nombre_complejo_poli { get; set; }
        public Nullable<bool> estado { get; set; }
        public string fecha_actualizacion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities.EntitiesBD
{
    public class SP_MAN_SEDE_LISTADO_Result
    {
        public int id_sede { get; set; }
        public string cod_sede { get; set; }
        public string nombre_sede { get; set; }
        public Nullable<int> numero_complejos { get; set; }
        public Nullable<decimal> presupuesto { get; set; }
        public Nullable<bool> estado { get; set; }
        public string fecha_actualizacion { get; set; }
    }
}

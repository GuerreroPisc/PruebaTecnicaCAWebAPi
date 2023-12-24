using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities.ComplejoPolideportivo
{
    public class ListadoComplejoPolideportivo
    {
        public HttpStatusCode codigoRes { get; set; }
        public string mensajeRes { get; set; }
        public List<ItemComplejoPolideportivo> datos { get; set; }
    }
    public class ItemComplejoPolideportivo
    {
        public int id_complejo_poli { get; set; }
        public string nombre_sede { get; set; }
        public string cod_complejo_poli { get; set; }
        public string nombre_complejo_poli { get; set; }
        public Nullable<bool> estado { get; set; }
        public string fecha_actualizacion { get; set; }
    }
}

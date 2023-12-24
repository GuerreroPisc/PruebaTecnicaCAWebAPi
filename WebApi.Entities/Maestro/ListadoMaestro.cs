using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities.Maestro
{
    public class ListadoMaestro
    {
        public HttpStatusCode codigoRes { get; set; }
        public string mensajeRes { get; set; }
        public List<ItemMaestroSede> datosSede { get; set; }
    }
    public class ItemMaestroSede
    {
        public int id_sede { get; set; }
        public string cod_sede { get; set; }
        public string nombre_sede { get; set; }
    }
}

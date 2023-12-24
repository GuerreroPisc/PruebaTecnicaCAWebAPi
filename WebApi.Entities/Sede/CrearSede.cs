using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities.Sede
{
    public class CrearSede
    {
        public HttpStatusCode codigoRes { get; set; }
        public string mensajeRes { get; set; }
        public int id_sede { get; set; }
    }

    public class CrearSedeSP
    {
        public int codigoRes { get; set; }
        public string mensajeRes { get; set; }
        public int id_sede { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities.ComplejoPolideportivo
{
    public class CrearComplejoPolideportivo
    {
        public HttpStatusCode codigoRes { get; set; }
        public string mensajeRes { get; set; }
        public int id_complejo_poli { get; set; }
    }

    public class CrearComplejoPolideportivoSP
    {
        public int codigoRes { get; set; }
        public string mensajeRes { get; set; }
        public int id_complejo_poli { get; set; }
    }
}

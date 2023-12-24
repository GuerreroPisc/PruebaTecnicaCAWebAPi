using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities.ComplejoPolideportivo
{
    public class DetalleComplejoPolideportivo
    {
        public HttpStatusCode codigoRes { get; set; }
        public string mensajeRes { get; set; }
        public ItemComplejoPolideportivoDetalle datos { get; set; }
    }
    public class ItemComplejoPolideportivoDetalle
    {
        public int id_complejo_poli { get; set; }
        public int id_sede { get; set; }
        public string cod_complejo_poli { get; set; }
        public string nombre_complejo_poli { get; set; }
        public Nullable<bool> estado { get; set; }
    }
}

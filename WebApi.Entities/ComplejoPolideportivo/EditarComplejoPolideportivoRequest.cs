using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities.ComplejoPolideportivo
{
    public class EditarComplejoPolideportivoRequest
    {
        public int id_sede { get; set; }
        public string nombre_complejo_poli { get; set; }
        public bool estado { get; set; }
    }
}

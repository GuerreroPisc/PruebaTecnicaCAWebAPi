//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class trs_usuario
    {
        public int id_usuario { get; set; }
        public int id_persona { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public string usuario_registro { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
        public string usuario_modificacion { get; set; }
    }
}

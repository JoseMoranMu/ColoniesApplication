//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class personal
    {
        public string DNI { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string teléfono { get; set; }
        public string email { get; set; }
    
        public virtual administrador administrador { get; set; }
        public virtual monitor monitor { get; set; }
    }
}
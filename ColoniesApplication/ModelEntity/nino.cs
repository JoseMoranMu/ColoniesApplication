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
    
    public partial class nino
    {
        public nino()
        {
            this.inscripciones_tanda_casa = new HashSet<inscripciones_tanda_casa>();
            this.nino1 = new HashSet<nino>();
            this.nino2 = new HashSet<nino>();
        }
    
        public int carnet { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string sexo { get; set; }
        public int anio_nacimiento { get; set; }
        public string codigo_poblacion { get; set; }
    
        public virtual ICollection<inscripciones_tanda_casa> inscripciones_tanda_casa { get; set; }
        public virtual poblacion poblacion { get; set; }
        public virtual ICollection<nino> nino1 { get; set; }
        public virtual ICollection<nino> nino2 { get; set; }
    }
}

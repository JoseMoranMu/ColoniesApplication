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
    
    public partial class tareas
    {
        public tareas()
        {
            this.monitor_tareas_tandas = new HashSet<monitor_tareas_tandas>();
        }
    
        public string codigo_tareas { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<monitor_tareas_tandas> monitor_tareas_tandas { get; set; }
    }
}
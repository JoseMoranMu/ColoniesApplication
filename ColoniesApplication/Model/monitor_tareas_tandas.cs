//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class monitor_tareas_tandas
    {
        public string DNI_monitor { get; set; }
        public string codigo_tarea { get; set; }
        public System.DateTime fecha_inicio_tanda { get; set; }
        public System.DateTime dia_tarea { get; set; }
    
        public virtual monitor monitor { get; set; }
        public virtual tareas tareas { get; set; }
        public virtual tanda tanda { get; set; }
    }
}

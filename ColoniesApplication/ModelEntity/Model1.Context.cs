﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class coloniesEntities : DbContext
    {
        public coloniesEntities()
            : base("name=coloniesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<actividad> actividad { get; set; }
        public DbSet<actividad_casa> actividad_casa { get; set; }
        public DbSet<administra_casa> administra_casa { get; set; }
        public DbSet<administrador> administrador { get; set; }
        public DbSet<casa> casa { get; set; }
        public DbSet<inscripciones_tanda_casa> inscripciones_tanda_casa { get; set; }
        public DbSet<monitor> monitor { get; set; }
        public DbSet<monitor_tanda_casa> monitor_tanda_casa { get; set; }
        public DbSet<monitor_tareas_tandas> monitor_tareas_tandas { get; set; }
        public DbSet<nino> nino { get; set; }
        public DbSet<personal> personal { get; set; }
        public DbSet<poblacion> poblacion { get; set; }
        public DbSet<tanda> tanda { get; set; }
        public DbSet<tareas> tareas { get; set; }
    }
}

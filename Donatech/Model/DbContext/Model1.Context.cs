﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Donatech.Model.DbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DonatechEntities : DbContext
    {
        public DonatechEntities()
            : base("name=DonatechEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comuna> Comuna { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Mensaje> Mensaje { get; set; }
    }
}

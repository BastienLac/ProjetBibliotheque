﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetBibliotheque
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bibliothequeEntities : DbContext
    {
        public bibliothequeEntities()
            : base("name=bibliothequeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<genrelivre> genrelivre { get; set; }
        public virtual DbSet<livre> livre { get; set; }
        public virtual DbSet<reserver> reserver { get; set; }
        public virtual DbSet<themelivre> themelivre { get; set; }
        public virtual DbSet<utilisateur> utilisateur { get; set; }
    }
}
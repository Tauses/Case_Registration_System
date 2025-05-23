using DAL.DALModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("RegistreringsSystem")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<DALAfdeling> Afdelinger { get; set; }
        public DbSet<DALMedarbejder> Medarbejdere { get; set; }
        public DbSet<DALSag> Sager { get; set; }
        public DbSet<DALRegistrering> Registreringer { get; set; } 


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // evt. konfiguration og seeding
        }

    }
}

using DiveLogDataAccess.Models;
using DiveLogDataAccess.Persistance.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DiveLogDataAccess.Persistance
{
    public class DiveContext : DbContext
    {
        public DiveContext() :base("name = DiveContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Dive> Dives { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DiveConfigurations());
        }
    }
}
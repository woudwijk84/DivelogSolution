using DiveDataAccess.Models;
using System.Data.Entity;

namespace DiveDataAccess.Persistance
{
    public class DiveContext : DbContext
    {
        public DiveContext() : base("name=DiveContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Dive> Dives { get; set; }

        //todo : override OnModelCreating to make the diveConfiguration so the data annotations can be removed from the model 
    }
}
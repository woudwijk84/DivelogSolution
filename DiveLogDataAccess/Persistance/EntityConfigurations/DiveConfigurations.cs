using DiveLogDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DiveLogDataAccess.Persistance.EntityConfigurations
{
    public class DiveConfigurations : EntityTypeConfiguration<Dive>
    {
        public DiveConfigurations()
        {
            Property(c => c.Location)
                .IsRequired().
                HasColumnName("Location")
                .HasMaxLength(30);

            Property(c => c.Date)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasColumnName("Date");
        }
    }
}
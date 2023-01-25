using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class BeerConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Alcohol_content).HasColumnType("decimal(18,2)"); ;
            builder.Property(b => b.Price).HasColumnType("decimal(18,2)");

            builder.HasOne(b => b.Brewer).WithMany().HasForeignKey(p => p.BrewerId);
        }

    }
}

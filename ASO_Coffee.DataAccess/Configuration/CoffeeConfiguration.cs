using ASP_Coffee.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.DataAccess.Configuration
{
    public class CoffeeConfiguration : IEntityTypeConfiguration<Coffee>
    {
        public void Configure(EntityTypeBuilder<Coffee> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Description).IsRequired();
            builder.HasIndex(x => x.Description);
            builder.Property(x => x.ImagePath).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.CoffeeAmounts)
                    .WithOne(x => x.Coffee)
                    .HasForeignKey(x => x.CoffeeId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

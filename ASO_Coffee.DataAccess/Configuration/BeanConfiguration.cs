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
    public class BeanConfiguration : IEntityTypeConfiguration<Bean>
    {
        public void Configure(EntityTypeBuilder<Bean> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.Coffees)
                    .WithOne(x => x.Bean)
                    .HasForeignKey(x => x.BeanId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

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
    public class AmountConfiguration : IEntityTypeConfiguration<Amount>
    {
        public void Configure(EntityTypeBuilder<Amount> builder)
        {
            builder.Property(x => x.AmountPack).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.AmountCoffees)
                   .WithOne(x => x.Amount)
                   .HasForeignKey(x => x.AmountId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

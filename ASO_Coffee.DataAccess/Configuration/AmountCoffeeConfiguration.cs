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
    public class AmountCoffeeConfiguration : IEntityTypeConfiguration<AmountCoffee>
    {
        public void Configure(EntityTypeBuilder<AmountCoffee> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
        }
    }
}

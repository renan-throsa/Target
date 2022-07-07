using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Target.Entities.Entities;

namespace Target.Repositories.Implementation.Mapping
{
    internal class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Code).HasMaxLength(13).IsRequired();
            builder.HasAlternateKey(p => p.Code);
        }
    }
}

using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence.EntityConfiguration
{
    public class InvoiceEntityTypeConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.InvoiceId);
            builder.Ignore(x => x.Id);

            builder.OwnsOne(x => x.InvoiceNumber) .Property(y => y.Value) .HasColumnName("InvoiceNumber") .HasMaxLength(3);
            builder.OwnsOne(x => x.ClientName) .Property(y => y.Value) .HasColumnName("ClientName") .HasMaxLength(200);
            builder.OwnsOne(x => x.TaxPayerIdentificationNumber).Property(y => y.Value).HasColumnName("TaxPayerIdentificationNumber").HasMaxLength(100);
            builder.OwnsOne(x => x.EmisionDate).Property(y => y.Value).HasColumnName("EmisionDate").HasMaxLength(10);
            builder.OwnsOne(x => x.AuthorizationId).Property(y => y.Value).HasColumnName("AuthorizationId").HasMaxLength(10);

            

        }
}
}
    


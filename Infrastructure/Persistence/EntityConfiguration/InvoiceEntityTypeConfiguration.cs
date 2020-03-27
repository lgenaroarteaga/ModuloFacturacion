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
            builder.OwnsOne(x => x.InvoiceNumber)
                .Property(y => y.Value)                
                .HasColumnName("InvoiceNumber")
                .HasMaxLength(3);


        }
}
}
    


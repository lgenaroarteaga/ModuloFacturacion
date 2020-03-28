using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence.EntityConfiguration
{
    class AuthorizationEntityTypeConfiguration : IEntityTypeConfiguration<Authorization>
    {
        public void Configure(EntityTypeBuilder<Authorization> builder)
        {
            builder.HasKey(x => x.AuthorizationId);
            builder.Ignore(x => x.Id);

            builder.OwnsOne(x => x.AuthorizationNumber).Property(y => y.Value).HasColumnName("AuthorizationNumber").HasMaxLength(100);
            builder.OwnsOne(x => x.TaxEmitterNumber).Property(y => y.Value).HasColumnName("TaxEmitterNumber").HasMaxLength(100);
            builder.OwnsOne(x => x.Name).Property(y => y.Value).HasColumnName("Name").HasMaxLength(100);
            builder.OwnsOne(x => x.LastEmmitedNumber).Property(y => y.Value).HasColumnName("LastEmmitedNumber").HasMaxLength(100);

            //builder.OwnsOne(x => x.ExpirationDate).Property(y => y.Value).HasColumnName("ExpirationDate").HasMaxLength(10);



        }
    }
}



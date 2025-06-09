using DDD.CarRental.Core.DomainModelLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.InfrastructureLayer.EF.EntityConfigurations
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedNever();
            builder.Ignore(r => r.DomainEvents);

            builder.Property(r => r.CarId);
            builder.Property(r => r.DriverId);
            builder.Property(r => r.Started);
            builder.Property(r => r.Finished);

            builder.OwnsOne(r => r.Total, m =>
            {
                m.Property(x => x.Amount).HasColumnName("TotalAmount");
                m.Property(x => x.Currency).HasColumnName("TotalCurrency");
            });
        }
    }
}

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
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Ignore(c => c.DomainEvents);

            builder.Property(c => c.RegistrationNumber);
            builder.Property(c => c.Status);

            // Konfiguracja ValueObjectów jako Owned Types
            builder.OwnsOne(c => c.CurrentPosition, pos =>
            {
                pos.Property(p => p.X).HasColumnName("PositionX");
                pos.Property(p => p.Y).HasColumnName("PositionY");
                pos.Property(p => p.Unit).HasColumnName("PositionUnit");
            });

            builder.OwnsOne(c => c.CurrentDistance, dist =>
            {
                dist.Property(d => d.Value).HasColumnName("CurrentDistanceValue");
                dist.Property(d => d.Unit).HasColumnName("CurrentDistanceUnit");
            });

            builder.OwnsOne(c => c.TotalDistance, dist =>
            {
                dist.Property(d => d.Value).HasColumnName("TotalDistanceValue");
                dist.Property(d => d.Unit).HasColumnName("TotalDistanceUnit");
            });
        }
    }
}

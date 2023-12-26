using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ShipperConfig : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.HasKey(s => s.ShipperID);
            builder.Property(s => s.ShipperName).IsRequired();
            builder.Property(s => s.PhoneNumber).IsRequired();

            builder.HasData(
                new Shipper() { ShipperID = 1, ShipperName = "Yurtici", PhoneNumber = "5555551234" },
                new Shipper() { ShipperID = 2, ShipperName = "MNG", PhoneNumber = "5555556789" }
            );
        }
    }
}
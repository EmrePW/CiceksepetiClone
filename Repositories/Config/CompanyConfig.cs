using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.CompanyID);

            builder.HasData(
                new Company { CompanyID = 1, UserID = "DefaultUserID", CompanyName = "DefaultCompany" },
                new Company { CompanyID = 2, UserID = "DefaultUserID2", CompanyName = "DefaultCompany2" }
            );
        }
    }
}
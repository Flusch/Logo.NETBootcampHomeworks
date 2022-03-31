using logo_odev4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace logo_odev4.DataAccess.EntityFramework.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies").HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}

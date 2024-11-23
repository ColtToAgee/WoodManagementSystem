using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Persistence.Configurations
{
    public class PatternConfiguration : IEntityTypeConfiguration<Pattern>
    {
        public void Configure(EntityTypeBuilder<Pattern> builder)
        {

        }
    }
}

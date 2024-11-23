using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Persistence.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {

        }
    }
}

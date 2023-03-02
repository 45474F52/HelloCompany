using HelloCompany.Model.DataBase.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HelloCompany.Model.DataBase.Configurations
{
    internal class PositionNameConfiguration : EntityTypeConfiguration<PositionName>
    {
        public PositionNameConfiguration()
        {
            ToTable(nameof(PositionName));

            HasKey(p => p.Position);

            Property(p => p.Position).HasMaxLength(266).IsUnicode();

            HasMany(p => p.Employees).WithRequired(e => e.PositionName).HasForeignKey(e => e.Position).WillCascadeOnDelete(true);
        }
    }
}
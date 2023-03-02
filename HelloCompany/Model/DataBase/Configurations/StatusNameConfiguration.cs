using HelloCompany.Model.DataBase.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HelloCompany.Model.DataBase.Configurations
{
    internal class StatusNameConfiguration : EntityTypeConfiguration<StatusName>
    {
        public StatusNameConfiguration()
        {
            ToTable(nameof(StatusName));

            HasKey(s => s.Status);

            Property(s => s.Status).HasMaxLength(16).IsUnicode(true);

            HasMany(s => s.Orders).WithRequired(o => o.StatusName).HasForeignKey(o => o.Status).WillCascadeOnDelete(true);
        }
    }
}
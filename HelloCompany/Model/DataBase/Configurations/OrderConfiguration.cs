using HelloCompany.Model.DataBase.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloCompany.Model.DataBase.Configurations
{
    internal class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable(nameof(Order));

            HasKey(o => o.ID);

            //??? HasIndex(o => o.Number).IsUnique();

            Property(o => o.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.Number).HasMaxLength(20).IsUnicode().IsRequired();
            Property(o => o.CreationDate).IsRequired().HasColumnType("DATE");
            Property(o => o.ClosingDate).IsOptional().HasColumnType("DATE");
            Property(o => o.Runtime).IsRequired().HasColumnType("SMALLINT");
            
            HasRequired(o => o.StatusName).WithMany(s => s.Orders).HasForeignKey(o => o.Status);
            HasRequired(o => o.Client).WithMany(c => c.Orders).HasForeignKey(o => o.ClientCode);
            HasRequired(o => o.Employee).WithMany(e => e.Orders).HasForeignKey(o => o.EmployeeCode);

            HasMany(o => o.Services).WithMany(s => s.Orders).Map(m => m.ToTable("OrdersServices").MapLeftKey("OrderID").MapRightKey("ServiceID"));
        }
    }
}
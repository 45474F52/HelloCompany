using HelloCompany.Model.DataBase.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloCompany.Model.DataBase.Configurations
{
    internal class ServiceConfiguration : EntityTypeConfiguration<Service>
    {
        public ServiceConfiguration()
        {
            ToTable(nameof(Service));

            HasKey(s => s.ID);

            HasIndex(s => s.Code).IsUnique();

            Property(s => s.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(s => s.Code).HasMaxLength(10).IsRequired().IsUnicode();
            Property(s => s.Name).IsRequired().IsUnicode();
            Property(s => s.PerformanceTime).IsRequired().HasColumnType("TINYINT");
            Property(s => s.MeanDeviation).IsRequired().HasPrecision(5, 3);
            Property(s => s.Price).IsRequired().HasColumnType("SMALLMONEY");
            Property(s => s.PriceRuCosmetics).IsRequired().HasColumnType("SMALLMONEY");

            HasMany(s => s.Employees).WithMany(e => e.Services).Map(m => m.ToTable("EmployeesServices").MapLeftKey("EmployeeID").MapRightKey("ServiceID"));
            HasMany(s => s.Orders).WithMany(o => o.Services).Map(m => m.ToTable("OrdersServices").MapLeftKey("OrderID").MapRightKey("ServiceID"));
        }
    }
}
using HelloCompany.Model.DataBase.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HelloCompany.Model.DataBase.Configurations
{
    internal class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable(nameof(Employee));

            HasKey(e => e.Code);

            HasIndex(e => e.Login).IsUnique();

            Property(e => e.Code).HasMaxLength(8).IsUnicode();
            Property(e => e.Login).HasMaxLength(266).IsRequired().IsUnicode();
            Property(e => e.Password).HasMaxLength(20).IsRequired().IsUnicode();
            Property(e => e.LastEntry).HasColumnType("DATETIME2").HasPrecision(byte.MinValue).IsRequired();

            HasRequired(e => e.PositionName).WithMany(p => p.Employees).HasForeignKey(e => e.Position).WillCascadeOnDelete(true);
            HasMany(e => e.Orders).WithRequired(o => o.Employee);
            HasMany(e => e.Services).WithMany(s => s.Employees).Map(m => m.ToTable("EmployeesServices").MapLeftKey("EmployeeID").MapRightKey("ServiceID"));
        }
    }
}
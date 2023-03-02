using HelloCompany.Model.DataBase.Entities.Complex;
using System.Data.Entity.ModelConfiguration;

namespace HelloCompany.Model.DataBase.Configurations
{
    internal class FullNameConfiguration : ComplexTypeConfiguration<FullName>
    {
        public FullNameConfiguration()
        {
            Property(f => f.Surname).IsRequired().IsUnicode();
            Property(f => f.FirstName).IsRequired().IsUnicode();
            Property(f => f.Patronymic).IsRequired().IsUnicode();
        }
    }
}
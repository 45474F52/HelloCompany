using HelloCompany.Model.DataBase.Entities.Complex;
using System.Data.Entity.ModelConfiguration;

namespace HelloCompany.Model.DataBase.Configurations
{
    internal class ContactConfiguration : ComplexTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            Property(c => c.Phone).IsRequired().IsUnicode().HasMaxLength(22);
        }
    }
}
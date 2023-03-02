using HelloCompany.Model.DataBase.Entities.Complex;
using System.Data.Entity.ModelConfiguration;

namespace HelloCompany.Model.DataBase.Configurations
{
    internal class PasportDataConfiguration : ComplexTypeConfiguration<PasportData>
    {
        public PasportDataConfiguration()
        {
            Property(p => p.FullData).HasMaxLength(23).IsMaxLength().IsRequired().IsUnicode();
        }
    }
}
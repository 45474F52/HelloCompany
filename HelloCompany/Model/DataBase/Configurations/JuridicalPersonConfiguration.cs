using HelloCompany.Model.DataBase.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloCompany.Model.DataBase.Configurations
{
    internal class JuridicalPersonConfiguration : EntityTypeConfiguration<JuridicalPerson>
    {
        public JuridicalPersonConfiguration()
        {
            ToTable(nameof(JuridicalPerson));

            HasIndex(j => j.ID).IsUnique();

            Property(j => j.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(j => j.CompanyName).IsRequired().IsUnicode();
            Property(j => j.INN).IsRequired();
            Property(j => j.Account).IsRequired();
            Property(j => j.BIC).IsRequired();
        }
    }
}
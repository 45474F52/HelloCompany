using HelloCompany.Model.DataBase.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloCompany.Model.DataBase.Configurations
{
    internal class NaturalPersonConfiguration : EntityTypeConfiguration<NaturalPerson>
    {
        public NaturalPersonConfiguration()
        {
            ToTable(nameof(NaturalPerson));

            HasIndex(j => j.ID).IsUnique();

            Property(j => j.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(n => n.BirthDate).HasColumnType("DATE").IsRequired();
        }
    }
}
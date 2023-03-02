using HelloCompany.Model.DataBase.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HelloCompany.Model.DataBase.Configurations
{
    internal class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            ToTable(nameof(Client));

            HasKey(c => c.Code);

            //Unique not invalid
            //HasIndex(c => c.Email).IsUnique();

            Property(c => c.Code).HasMaxLength(8).IsUnicode();
            Property(c => c.Address).IsRequired().IsUnicode();
            Property(c => c.Email).HasMaxLength(266).IsMaxLength().IsRequired().IsUnicode();
            Property(c => c.Password).HasMaxLength(20).IsRequired().IsUnicode();

            HasMany(c => c.Orders).WithRequired(o => o.Client);
        }
    }
}
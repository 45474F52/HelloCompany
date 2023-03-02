using HelloCompany.Model.DataBase.Entities;
using HelloCompany.Model.DataBase.Configurations;
using HelloCompany.Model.DataBase.Entities.Complex;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HelloCompany.Model.DataBase
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("name=Model") =>
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataBaseContext>());

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.ComplexType<Supervisor>();

            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new ContactConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new FullNameConfiguration());
            modelBuilder.Configurations.Add(new JuridicalPersonConfiguration());
            modelBuilder.Configurations.Add(new NaturalPersonConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new PasportDataConfiguration());
            modelBuilder.Configurations.Add(new PositionNameConfiguration());
            modelBuilder.Configurations.Add(new ServiceConfiguration());
            modelBuilder.Configurations.Add(new StatusNameConfiguration());
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<NaturalPerson> NaturalPeople { get; set; }
        public virtual DbSet<JuridicalPerson> JuridicalPeople { get; set; }
        public virtual DbSet<PositionName> PositionNames { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<StatusName> StatusNames { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
using Attorney.Manager.Domain.Addresses;
using Attorney.Manager.Domain.Registration;
using Microsoft.EntityFrameworkCore;

namespace Attorney.Manager.Repository.Context
{
    public class AttorneyManagerDbContext : DbContext
    {
        public AttorneyManagerDbContext()
        {

        }

        public AttorneyManagerDbContext(DbContextOptions<AttorneyManagerDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Domain.Registration.Attorney> Attorney { get; set; }
        public virtual DbSet<CommercialAdress> CommercialAdress { get; set; }
        public virtual DbSet<Seniority> Seniority { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region " Attorney "

            /* ColumnType configs */
            modelBuilder.Entity<Domain.Registration.Attorney>(e => e.Property(o => o.AttorneyId).ValueGeneratedOnAdd());
            modelBuilder.Entity<Domain.Registration.Attorney>(e => e.Property(a => a.Name).HasColumnType("nvarchar(125)"));

            /* ColumnName configs */
            modelBuilder.Entity<Domain.Registration.Attorney>(e => e.Property(a => a.AttorneyId).HasColumnName("attoreny_id"));
            modelBuilder.Entity<Domain.Registration.Attorney>(e => e.Property(a => a.Name).HasColumnName("name"));

            modelBuilder.Entity<Seniority>()
                .HasOne(p => p.Attorney)
                .WithMany(b => b.Seniority);

            modelBuilder.Entity<Seniority>()
               .HasOne(p => p.Attorney)
               .WithMany(b => b.Seniority);

            #endregion

            #region " CommercialAdress "

            /* ColumnType configs */
            modelBuilder.Entity<CommercialAdress>(e => e.Property(o => o.Id).ValueGeneratedOnAdd());
            modelBuilder.Entity<CommercialAdress>(e => e.Property(o => o.PostalCode).HasColumnType("nvarchar(10)"));
            modelBuilder.Entity<CommercialAdress>(e => e.Property(o => o.StreetName).HasColumnType("nvarchar(255)"));
            modelBuilder.Entity<CommercialAdress>(e => e.Property(o => o.City).HasColumnType("nvarchar(125)"));
            modelBuilder.Entity<CommercialAdress>(e => e.Property(o => o.State).HasColumnType("nvarchar(125)"));
            modelBuilder.Entity<CommercialAdress>(e => e.Property(o => o.Country).HasColumnType("nvarchar(125)"));

            /* ColumnName configs */
            modelBuilder.Entity<CommercialAdress>(e => e.Property(c => c.Id).HasColumnName("commercial_id"));
            modelBuilder.Entity<CommercialAdress>(e => e.Property(c => c.PostalCode).HasColumnName("postal_code"));
            modelBuilder.Entity<CommercialAdress>(e => e.Property(c => c.StreetName).HasColumnName("street_name"));
            modelBuilder.Entity<CommercialAdress>(e => e.Property(c => c.City).HasColumnName("city"));
            modelBuilder.Entity<CommercialAdress>(e => e.Property(c => c.State).HasColumnName("state"));
            modelBuilder.Entity<CommercialAdress>(e => e.Property(c => c.Country).HasColumnName("country"));

            #endregion

            #region " Seniority "

            /* ColumnType configs */
            modelBuilder.Entity<Seniority>(e => e.Property(s => s.SeniorityId).ValueGeneratedOnAdd());
            modelBuilder.Entity<Seniority>(e => e.Property(s => s.SeniorityType).HasColumnType("INT"));

            /* ColumnName configs */
            modelBuilder.Entity<Seniority>(e => e.Property(s => s.SeniorityType).HasColumnName("seniority"));

            #endregion

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=attorney_manager;Uid=root;Pwd=12345;");
            }
        }
    }
}

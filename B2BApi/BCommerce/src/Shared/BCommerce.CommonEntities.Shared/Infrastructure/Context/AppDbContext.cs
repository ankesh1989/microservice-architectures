using BCommerce.DataAccess.Shared.Interfaces;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IAuditLogService _auditLogService;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options, IAuditLogService auditLogService) : base(options)
        {
            _auditLogService = auditLogService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<BCOMCountry>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()")
                    .IsRequired();
                entity.Property(e => e.ModifiedOn)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()")
                    .IsRequired();
            });

            modelBuilder.Entity<BCOMState>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()")
                    .IsRequired();
                entity.Property(e => e.ModifiedOn)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()")
                    .IsRequired();
            });

            modelBuilder.Entity<BCOMCity>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()")
                    .IsRequired();
                entity.Property(e => e.ModifiedOn)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()")
                    .IsRequired();
            });

            modelBuilder.Entity<BCOMSupplier>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()")
                    .IsRequired();
                entity.Property(e => e.ModifiedOn)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NOW()")
                    .IsRequired();
            });
        }


        public DbSet<BCOMCountry> BCOMCountries { get; set; }
        public DbSet<AuditLog> CommonAuditLogs { get; set; }
        public DbSet<BCOMState> BCOMStates { get; set; }
        public DbSet<BCOMCity> BCOMCities { get; set; }
        public DbSet<BCOMContinent> BCOMContinents { get; set; }
        public DbSet<BCOMLanguage> BCOMLanguages { get; set; }

        public DbSet<BCOMCurrency> BCOMCurrency { get; set; }
        public DbSet<BCOMFieldType> BCOMFieldType { get; set; }
        public DbSet<BCOMFunction> BCOMFunction { get; set; }

        public DbSet<BCOMMarket> BCOMMarket { get; set; }
        public DbSet<BCOMProduct> BCOMProduct { get; set; }
        public DbSet<BCOMTheme> BCOMTheme { get; set; }
        public DbSet<BCOMExchangeRate> BCOMExchangeRate { get; set; }
        public DbSet<BCOMEventType> BCOMEventType { get; set; }
        public DbSet<BCOMDocument> BCOMDocument { get; set; }
        public DbSet<BCOMAgentConfig> BCOMAgentConfig { get; set; }
        public DbSet<BCOMAgentDoc> BCOMAgentDoc { get; set; }
        public DbSet<BCOMAgentFinance> BCOMAgentFinance { get; set; }
        public DbSet<BCOMAgentFOP> BCOMAgentFOP { get; set; }
        public DbSet<BCOMAgentPg> BCOMAgentPg { get; set; }
        public DbSet<BCOMAgentProfile> BCOMAgentProfile { get; set; }
        public DbSet<BCOMAgentPOC> BCOMAgentsPOC { get; set; }
        public DbSet<BCOMAgentSupplier> BCOMAgentSupplier { get; set; }
        public DbSet<BCOMLocation> BCOMLocation { get; set; }
        public DbSet<BCOMSupplierDocument> BCOMSupplierDocument { get; set; }
        public DbSet<BCOMSupplierConfig> BCOMSupplierConfig { get; set; }
        public DbSet<BCOMSupplier> BCOMSupplier { get; set; }
        public DbSet<BCOMRole> BCOMRole { get; set; }
        public DbSet<BCOMAppConfig> BCOMAppConfig { get; set; }
        public DbSet<BCOMPrivilege> BCOMPrivilege { get; set; }

        public DbSet<BCOMRoleDetails> BCOMRoleDetails { get; set; }
        public DbSet<BCOMUser> BCOMUser { get; set; }
        public DbSet<BCOMUserRole> BCOMUserRole { get; set; }
        public DbSet<BCOMUserprivilege> BCOMUserprivilege { get; set; }

        public virtual async Task<int> SaveChangesAsync(string userId = "")
        {
            _auditLogService.SetCreatedAndModified(this);
            return await base.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAndLogsAsync<TEntity>(TEntity oldEntity, TEntity newEntity, string userId = "") where TEntity : class
        {
            _auditLogService.SetCreatedAndModified(this);
            Type auditEntryType = typeof(AuditEntry);
            Type auditLogType = typeof(AuditLog);
            _auditLogService.LogAudit(this, oldEntity, newEntity, auditEntryType, auditLogType, CommonAuditLogs, userId);
            return await base.SaveChangesAsync();
        }
    }
}

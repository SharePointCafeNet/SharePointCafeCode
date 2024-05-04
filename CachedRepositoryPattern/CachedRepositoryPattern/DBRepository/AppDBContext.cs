using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CachedRepositoryPattern.Models;
using System.Data;


namespace CachedRepositoryPattern.DBRepository
{
    public class AppDBContext: DbContext
    {
        private IConfiguration _configuration;
        private const string _connectionString = "Server=Server1;Database=MyDB1;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=SSPI;TrustServerCertificate= True";

        public AppDBContext(DbContextOptions<AppDBContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Content> Content { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // base.OnConfiguring(optionsBuilder);
           if(! optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, sqlServerOptions =>
                sqlServerOptions.CommandTimeout(300));
            }
        }
    }
}

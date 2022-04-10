using Microsoft.EntityFrameworkCore;
using DBMigrationDemo.Models;

namespace DBMigrationDemo.Data
{
    public class SqlDBContext  : DbContext
    {
        public SqlDBContext (DbContextOptions<SqlDBContext> options) : base(options)
        {
        }

        public DbSet<FeatureFlag> FeatureFlags { get; set; }
        public DbSet<RuleItem> RuleItems { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<Rule> Rules { get; set; }
    }
}

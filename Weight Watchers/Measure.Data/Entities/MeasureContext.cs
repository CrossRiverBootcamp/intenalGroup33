
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Measure.Data.Entities
{
    public class MeasureContext:DbContext
    {
        public readonly IConfiguration _configuration;
        public MeasureContext(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        public DbSet<MeasureEntity> Measurements { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(_configuration.GetConnectionString("myConnection"));
        }
    }
}

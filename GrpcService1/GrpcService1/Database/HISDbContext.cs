using GrpcService1.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrpcService1.Database
{
    public class HISDbContext : DbContext
    {
        public HISDbContext(DbContextOptions<HISDbContext> options)
: base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var config = modelBuilder.Entity<PatientEntity>();
            config.ToTable("utb_BenhNhan");
        }
        public DbSet<PatientEntity> Patients { get; set; }
    }
}

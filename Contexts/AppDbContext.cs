using Microsoft.EntityFrameworkCore;
using SmartB.API.Entities;

namespace SmartB.API.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Angajati> Angajatis { get; set; }
        public DbSet<Articole> Articoles { get; set; }
        public DbSet<Comenzi> Comenzis { get; set; }
        public DbSet<Masini> Masinis { get; set; }
        public DbSet<Operatii> Operatiis { get; set; }
        public DbSet<OperatiiArticol> OperatiiArticols { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<MachinePhase> MachinePhases { get; set; }
        public DbSet<Realizari> Realizari { get; set; }
        public DbSet<Butoane> Butoane { get; set; }
        public DbSet<CommessaTIM> CommessaTim { get; set; }
        public DbSet<Pause> Pause { get; set; }
        public  DbSet<JobEfficiency> JobEfficiency { get; set; }
        public DbSet<Devices> Devices { get; set; }
        public DbSet<DeviceInfo> DeviceInfo { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

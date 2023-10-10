using ABTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ABTest.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<DeviceExperiment> DeviceExperiments { get; set; }
        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Устанавливаем составной ключ для таблицы DeviceExperiments
            modelBuilder.Entity<DeviceExperiment>()
                .HasKey(de => new { de.DeviceId, de.ExperimentId });
            // Определяем отношение "один ко многим" между Device и DeviceExperiments
            modelBuilder.Entity<DeviceExperiment>()
                .HasOne(d => d.Device)
                .WithMany(de => de.DeviceExperiments)
                .HasForeignKey(de => de.DeviceId)
                .OnDelete(DeleteBehavior.Restrict);
            // Определяем отношение "один ко многим" между Experiment и DeviceExperiments
            modelBuilder.Entity<DeviceExperiment>()
                .HasOne(e => e.Experiment)
                .WithMany(de => de.DeviceExperiments)
                .HasForeignKey(e  => e.ExperimentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

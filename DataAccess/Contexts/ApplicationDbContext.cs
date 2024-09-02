using Entity.Models;
using Helpers.FileSystem;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DataAccess.Contexts
{
    /// <summary>
    /// Default Application Db Context
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        private bool _created;

        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Position> Positions { get; set; }

        /// <summary>
        /// Default parameter constructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext()
        {
            if (!_created)
            {
                if (FileManagementHelper.EnsureCreateDatabasePath())
                {
                    Database.EnsureDeleted();
                    Database.EnsureCreated();

                    _created = true;
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(FileManagementHelper.DatabaseFilePath());
        }

        /// <summary>
        /// Overload of OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.SetPositionConfiguration(modelBuilder);
            this.SeedSoldierSamples(modelBuilder);
        }

        /// <summary>
        /// Configures position properties numeric precision
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void SetPositionConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>()
                .Property(p => p.Latitude)
                .HasColumnType("decimal(9,6)");

            modelBuilder.Entity<Position>()
                .Property(p => p.Longitude)
                .HasColumnType("decimal(9,6)");
        }

        /// <summary>
        /// Looks for soldier population json file and seeds the database in case it's not empty
        /// </summary>
        private void SeedSoldierSamples(ModelBuilder modelBuilder)
        {
            var fileContent = Task.Run(() => FileManagementHelper.ReadTextFileAsync()).GetAwaiter().GetResult();

            if (!string.IsNullOrWhiteSpace(fileContent))
            {
                try
                {
                    var soldiers = JsonConvert.DeserializeObject<List<Soldier>>(fileContent);

                    modelBuilder.Entity<Country>().HasData(soldiers.Select(s => s.Country).Distinct());

                    modelBuilder.Entity<Position>().HasData(soldiers.SelectMany(soldier => soldier.Sensors).Distinct().SelectMany(sensor => sensor.Positions).Distinct());

                    var sensors = soldiers.SelectMany(soldier => soldier.Sensors).Distinct();

                    foreach (var item in sensors)
                    {
                        item.Positions = null;
                    }

                    modelBuilder.Entity<Sensor>().HasData(sensors);

                    foreach (var item in soldiers)
                    {
                        item.Country = null;
                        item.Sensors = null;
                    }

                    modelBuilder.Entity<Soldier>().HasData(soldiers);
                }
                catch (Exception ex)
                {
                    //Not important
                }
                finally
                {
                    //FileManagementHelper.DeleteSampleFile();
                }
            }
        }
    }
}

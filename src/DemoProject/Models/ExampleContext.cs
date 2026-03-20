using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DotNetEnv;
namespace DemoProject.Models
{
    public partial class ExampleContext : DbContext
    {
        public ExampleContext()
        {

        }
        public ExampleContext(DbContextOptions<ExampleContext> options) : base(options)
        {

        }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public static void LoadEnvironment()
        {
            try
            {
                string fileName = ".env";
                string path = fileName;
                while (!File.Exists(path) && !(Path.GetFullPath(path) == Path.GetPathRoot(Path.GetFullPath(path)) + fileName))
                {
                    Console.WriteLine("Full Path: " + Path.GetFullPath(path));
                    Console.WriteLine("Root Path: " + Path.GetPathRoot(Path.GetFullPath(path)) + fileName);
                    path = "../" + path;
                }
                Env.Load(path);
            }
            catch
            {
                Console.WriteLine("ERROR: Failed to find .env!");
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            LoadEnvironment();
            string envDBType = Environment.GetEnvironmentVariable("DB_TYPE") ?? "sqlite";
            if (!optionsBuilder.IsConfigured)
            {
                if (envDBType.Trim().ToLower() == "mariadb" || envDBType.Trim().ToLower() == "mysql")
                {
                    optionsBuilder.UseMySql($"Server={Environment.GetEnvironmentVariable("DB_HOST") ?? ""};" +
                        $"Port=3306;" +
                        $"Database={Environment.GetEnvironmentVariable("DB_NAME") ?? ""};UID=root;PWD=;", new MariaDbServerVersion("10.4.28-MariaDB"));
                }
                else if (envDBType.Trim().ToLower() == "postgres")
                {
                    optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=postgres;UID=postgres;PWD=password");
                }
                else
                {
                    string dbName = "example.db";
                    string exactPath = Path.Combine(Directory.GetCurrentDirectory(), dbName);
                    if (!File.Exists(exactPath))
                    {
                        File.Create(exactPath).Close();
                    }
                    optionsBuilder.UseSqlite($"Filename={dbName};");
                }
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasData([
                    new Manufacturer() {
                        ID = -1,
                        Name = "Toyota"
                    },
                    new Manufacturer() {
                        ID = -2,
                        Name = "Mitsubishi"
                    }
                ]);
            });
            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasOne(child => child.Manufacturer)
                .WithMany(parent => parent.Models)
                .HasForeignKey(child => child.ManufacturerID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_${nameof(Model)}_{nameof(Manufacturer)}");
                entity.HasData([
                    new Model() {
                        ID = -1,
                        Name = "Supra",
                        ManufacturerID = -1,
                    },
                    new Model() {
                        ID = -2,
                        Name = "Soarer",
                        ManufacturerID = -1,
                    },
                    new Model() {
                        ID = -3,
                        Name = "3000GT",
                        ManufacturerID = -2,
                    },
                    new Model() {
                        ID = -4,
                        Name = "Eclipse",
                        ManufacturerID = -2
                    }
                ]);
            });
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasOne(child => child.Model)
                    .WithMany(parent => parent.Vehicles)
                    .HasForeignKey(child => child.ModelID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName($"FK_${nameof(Vehicle)}_{nameof(Model)}");
                entity.HasData(
                    new Vehicle()
                    {
                        VIN = "VIN00000000000001",
                        ModelID = -1, // Supra
                        ModelYear = 1998,
                        Colour = "Red"
                    },
                    new Vehicle()
                    {
                        VIN = "VIN00000000000002",
                        ModelID = -2, // Soarer
                        ModelYear = 1995,
                        Colour = "Black"
                    },
                    new Vehicle()
                    {
                        VIN = "VIN00000000000003",
                        ModelID = -3, // 3000GT
                        ModelYear = 1999,
                        Colour = "White"
                    },
                    new Vehicle()
                    {
                        VIN = "VIN00000000000004",
                        ModelID = -4, // Eclipse
                        ModelYear = 2001,
                        Colour = "Blue"
                    }
                );
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}

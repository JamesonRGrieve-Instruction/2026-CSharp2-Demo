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
        public virtual DbSet<ExampleTable> ExampleTables { get; set; }
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
            modelBuilder.Entity<ExampleTable>(entity =>
            {
                entity.HasData(
                    [new ExampleTable()
                    {
                        ID = -1
                    },new ExampleTable()
                    {
                        ID = -2
                    },new ExampleTable()
                    {
                        ID = -3
                    }]
                );
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}

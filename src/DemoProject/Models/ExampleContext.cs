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
        public virtual DbSet<Student> ExampleTables { get; set; }
        public virtual DbSet<ClassRoom> ExampleParents { get; set; }
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
            modelBuilder.Entity<ClassRoom>(entity =>
            {
                entity.HasData([
                    new ClassRoom() {
                        ID = -1,
                        RoomNumber = 101
                    },
                    new ClassRoom() {
                        ID = -2,
                        RoomNumber = 102
                    }
                ]);
            });
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasOne(child => child.ClassRoom)
                    .WithMany(parent => parent.Students)
                    .HasForeignKey(child => child.ClassRoomID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName($"FK_${nameof(Student)}_{nameof(ClassRoom)}");
                entity.HasData(
                    [new Student()
                    {
                        ID = -1,
                        ClassRoomID = -1,
                        FirstName = "John",
                        LastName = "Doe"
                    },new Student()
                    {
                        ID = -2,
                        ClassRoomID = -1,
                        FirstName = "Jane",
                        LastName = "Doe"
                    },new Student()
                    {
                        ID = -3,
                        ClassRoomID = -1,
                        FirstName = "Test",
                        LastName = "Student"
                    },
                    new Student()
                    {
                        ID = -4,
                        ClassRoomID = -2,
                        FirstName = "A",
                        LastName = "Student"
                    },new Student()
                    {
                        ID = -5,
                        ClassRoomID = -2,
                        FirstName = "B",
                        LastName = "Student"
                    },new Student()
                    {
                        ID = -6,
                        ClassRoomID = -2,
                        FirstName = "C",
                        LastName = "Student"
                    },
                    ]
                );
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}

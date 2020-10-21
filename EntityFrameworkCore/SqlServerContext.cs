using Microsoft.EntityFrameworkCore;
using ModelsCore.TableModels;
using System.Security.Cryptography.X509Certificates;

namespace EntityFrameworkCore
{
    public class SqlServerContext : DbContext
    {
        /// <summary>
        /// We call the construcor to be able to initialze the context on startup instead of later
        /// </summary>
        /// <param name="options"></param>
        public SqlServerContext(DbContextOptions options)
        : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        /// <summary>
        /// We use the fluent API in the model builder to Map the models.
        /// This allows us to Create a database from code using the Code First Approach
        /// and the command Update-Database
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Lets do the Student table First*/
            modelBuilder.Entity<Student>(e => {
                // Set key
                e.HasKey(e => e.Id);

                // Set the Non Null values
                e.Property(p => p.Id)
                 .IsRequired();

                e.Property(p => p.Name)
                 .IsRequired();

                e.Property(p => p.Age)
                 .IsRequired();

            });


            /* Then the subject table */
            modelBuilder.Entity<Subject>(e => {
                // Set key
                e.HasKey(e => e.Code);

                // Set the Non Null values
                e.Property(p => p.Description);

            });
        }

    }
}

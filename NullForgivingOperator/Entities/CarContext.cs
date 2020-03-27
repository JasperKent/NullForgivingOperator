using Microsoft.EntityFrameworkCore;

namespace NullForgivingOperator.Entities
{
    public class CarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NullForgivingOperatorDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Engine> Engines { get; set; } = null!;
        public DbSet<MotorCar> Cars { get; set; } = null!;
        public DbSet<Licence> Licences { get; set; } = null!;

        public static void Populate()
        {
            using CarContext context = new CarContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            MotorCar car = new MotorCar
            {
                Driver = new Person { Name = "Jenson", Licence = new Licence { Description = "Provisional" } },
                Engine = new Engine { Capacity = 1600 },
                Model = "MCL34"
            };

            context.Add(car);

            context.SaveChanges();
        }
    }
}

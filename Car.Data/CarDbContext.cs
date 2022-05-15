using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace Car.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext()
            : base("name=CarDbContext") { }
        public virtual DbSet<Car> Cars { get; set; }
    }

    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        public DateTime ModelYear { get; set; }
    }
}
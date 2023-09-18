using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data
{
    public class CarQueries
    {
        private CarDbContext ctx = new CarDbContext();
        private Random rand = new Random();
        public Task<List<Car>> GetAllCars()
        {
            return Task.Run(() =>
            {
                return ctx.Cars.ToList();
            });
        }
        public Task<List<Car>> GetFilteredCars()
        {
            IQueryable<Car> query = ctx.Cars.Where(c => c.Make.StartsWith("A")).OrderBy(c => c.ModelYear);
            return query.ToListAsync();
        }

        public Car GetRandomCar()
        {
            var cars = ctx.Cars.ToList();
            return cars[rand.Next(cars.Count)];
        }
        public async Task CreateRandomData(int count)
        {
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                cars.Add(GetRandomCar());
            }
            ctx.Cars.AddRange(cars);

            await ctx.SaveChangesAsync();
        }
        public async Task<int> GetCarsCount()
        {
            return await ctx.Cars.CountAsync();
        }
    }
}

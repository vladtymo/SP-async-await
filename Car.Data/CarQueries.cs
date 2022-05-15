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
        public Task<IEnumerable<Car>> GetAllCars()
        {
            return Task.Run(() =>
            {
                return (IEnumerable<Car>)ctx.Cars.ToList();
            });
        }
        public async Task<IEnumerable<Car>> GetFilteredCars()
        {
            IQueryable<Car> query = ctx.Cars.Where(c => c.Make.StartsWith("A")).OrderBy(c => c.ModelYear);
            return await query.ToListAsync();
        }

        public async Task<Car> GetRandomCar()
        {
            var cars = await ctx.Cars.ToListAsync();
            return cars[rand.Next(cars.Count)];
        }
        public async Task CreateRandomData(int count)
        {
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                cars.Add(await GetRandomCar());
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

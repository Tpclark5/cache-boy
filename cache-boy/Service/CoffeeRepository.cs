using cache_boy.Service;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using cache_boy.Models.CoffeeModel;

namespace cache_boy.Controllers
{

    public class CoffeeRepository : ICoffeeRepository
        
    {
        const string coffeeKey = "coffees";
        private readonly IMemoryCache _memoryCache;

        public  CoffeeRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

            if (!memoryCache.TryGetValue("coffees", out var coffee))
            {
                memoryCache.Set(coffeeKey, GetInitialCoffees());
            }
        }


        public static IList<Coffee> GetInitialCoffees()
        {

            Coffee cafe = new Coffee("Cafe Con Leche", "Scalded milk with bold coffee", 1, 3.75);
            var yummy = new Coffee("Yummy boys coffee", "Just plain old good coffee", 2, 5.00);
            var latte = new Coffee("Vanilla Latte", "Frother milk with a shot of espresso", 3, 2.50);
            var hotChoc = new Coffee("Hot Chocolate", "It's chocolate and it's hot", 4, 3.25);

            var coffees = new List<Coffee>()
            {
                cafe, yummy, latte, hotChoc
            };

            return coffees;
        }

        private IList<Coffee> Coffees
        {
            get
            {
                IList<Coffee> coffees;
                if (_memoryCache.TryGetValue(coffeeKey, out coffees))
                {
                    coffees = GetInitialCoffees();
                    _memoryCache.Set(coffeeKey, coffees);
                }
                return coffees;
            }
        }

        public void AddCoffee(Coffee coffee)
        {
            Coffees.Add(coffee);


        }

        public void DeleteCoffee(Coffee coffeeName)
        {
           
                Coffees.Remove(coffeeName);
            
        }

        public ICollection<Coffee> GetAllCoffee()
        {

            return Coffees;
        }

        public void UpdateCoffee(Coffee oldCoffee, Coffee newCoffee)
        {

                var oldNameIndex = Coffees.IndexOf(oldCoffee);
                Coffees[oldNameIndex] = newCoffee;

        }
    }
}

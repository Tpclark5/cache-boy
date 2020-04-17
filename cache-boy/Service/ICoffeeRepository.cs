using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cache_boy.Models.CoffeeModel;

namespace cache_boy.Service
{
    public interface ICoffeeRepository
    {
        void AddCoffee(Coffee coffeeName);

        void DeleteCoffee(Coffee coffeeName);

        void UpdateCoffee(Coffee oldCoffee, Coffee newCoffee);

        ICollection<Coffee> GetAllCoffee();
    }
}

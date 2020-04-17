using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cache_boy.Service;

namespace cache_boy.Models.CoffeeModel
{
    public class CoffeesViewModel
    {
        public IList<Coffee> Coffees {get; set;}
    }
}

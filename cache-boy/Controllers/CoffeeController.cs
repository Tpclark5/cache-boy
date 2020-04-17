using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cache_boy.Models;
using Microsoft.Extensions.Caching.Memory;
using cache_boy.Models.CoffeeModel;
using cache_boy.Service;

namespace cache_boy.Controllers
{
    public class CoffeeController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public CoffeeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

            if (!memoryCache.TryGetValue("coffees", out var coffee))
            {
                memoryCache.Set("coffees", CoffeeRepository.GetInitialCoffees());
            }
        }

        public IActionResult Coffees()
        {
            var model = new CoffeesViewModel();
            if (_memoryCache.TryGetValue("coffees", out IList<Coffee> coffees))
            {
                model.Coffees = coffees;
            }

            return View(model);
        }

        public IActionResult AddCoffee()
        {
            var model = new AddCoffeeViewModel();
            return View(model);
        }

        public IActionResult PostCoffee(Coffee coffee)
        {

            if(_memoryCache.TryGetValue("coffees", out ICollection<Coffee> coffees))
            {
                coffees.Add(coffee);
            }


            return View();
        }

        public IActionResult DeleteCoffee(int coffeeId) 
        {
          
          
            const string coffeeKey = "coffees";
            if (_memoryCache.TryGetValue(coffeeKey, out IList<Coffee> coffees))
            {
                foreach(var coffee in coffees)
                    {
                        if(coffeeId == coffee.Id)
                        {
                            coffees.Remove(coffee);
                        }

                    }
                
            }

            return RedirectToAction(nameof(Coffees)); 
        }

        public IActionResult UpdateCoffee(string coffeeName)
        {

            var model = new UpdateCoffeeViewModel();
            model.NewName = string.Empty;
            model.OldName = coffeeName;


            return View(model);
        }

        public IActionResult UpdatedCoffee(UpdateCoffeeViewModel model)
        {
         
            
            const string coffeeKey = "coffees";
            if (_memoryCache.TryGetValue(coffeeKey, out IList<Coffee> coffees)) 
            {
                foreach(var coffee in coffees)
                {
                        if(model.Id == coffee.Id){
                            coffee.Name = model.NewName;
                        }
                }
        
                
            }

            return RedirectToAction(nameof(Coffees));
        }
    }
}

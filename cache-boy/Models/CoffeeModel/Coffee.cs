using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cache_boy.Models.CoffeeModel

{
    public class Coffee
    {
     
     public Coffee(string name, string description, int id, double price)
    {
        Name = name;
        Description = description;
        Id = id;
        Price = price;
    }
      public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
    }
    
     
}

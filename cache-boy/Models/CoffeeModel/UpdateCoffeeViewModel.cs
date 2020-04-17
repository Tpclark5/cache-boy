using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cache_boy.Models.CoffeeModel
{
    public class UpdateCoffeeViewModel
    {
        public string OldName { get; set; }

        public string NewName { get; set; }

        public string Description {get; set;}

        public double Price {get; set;}

        public int Id {get; set;}
    }
}

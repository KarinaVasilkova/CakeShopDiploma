using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Model.Entities
{
    public class Measure
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Fullname { set; get; }
        public virtual List<Ingredient> Ingredients { set; get; }

    }
}

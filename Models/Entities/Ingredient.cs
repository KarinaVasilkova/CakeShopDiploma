using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Model.Entities
{
    public class Ingredient
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Measureid  { set; get; }
        public virtual Measure Measure { set; get; }
        public virtual List<cakeBase> Biscuits { set; get; }
        public virtual List<cakeCream> Creams { set; get; }
        public virtual List<cakeDecoration> Decors { set; get; }
        public virtual List<cakeFilling> Fruits { set; get; }

    }
}

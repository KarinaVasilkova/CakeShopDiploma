using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Model.Entities
{
    public class cakeCream
    {
        public int id { set; get; }
        public string name { set; get; }
        public int price { set; get; }
        //public int IngredientID { set; get; }
        //public virtual Ingredient Ingredient { set; get; }
        public virtual List<CreamCake> Cream { set; get; } = new List<CreamCake>();

    }
}

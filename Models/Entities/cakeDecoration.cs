using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Model.Entities
{
    public class cakeDecoration
    {
        public int id { set; get; }
        public string name { set; get; }
        public int price { set; get; }
        public string imgURL { set; get; }
        //public int IngredientID { set; get; }
        //public virtual Ingredient Ingredient { set; get; }
        public virtual List<DecorCake> Decor { set; get; } = new List<DecorCake>();
    }
}

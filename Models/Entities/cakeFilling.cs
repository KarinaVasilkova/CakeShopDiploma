using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Model.Entities
{
    public class cakeFilling
    {
        public int id { set; get; }
        public string name { set; get; }
        public int price { set; get; }
        //public int IngredientID { set; get; }
        //public virtual Ingredient Ingredient { set; get; }
        public virtual List<FillingCake> Fruit { set; get; } = new List<FillingCake>();
    }
}

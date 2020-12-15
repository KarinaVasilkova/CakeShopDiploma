using Models.Entities;
using ShopWebApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopWebApp.Model.Entities
{
    public class cakeCoating
    {
        public int id { set; get; }
        public string name { set; get; }
        public int price { set; get; }
        public string imgURL { set; get; }
        public virtual List<CoatingCake> Coating { set; get; } = new List<CoatingCake>();
    }
}

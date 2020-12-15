using Models.Entities;
using System;
using System.Collections.Generic;

namespace ShopWebApp.Model.Entities
{
    public class Cake
    {
        public int idCake { set; get; }
        public string nameCake { set; get; }
        public string imgURL { set; get; }
        public string aboutCake { set; get; }
        public string weightCake { set; get; }
        public ushort priceCake { set; get; }
        public string status { get; set; }
        public DateTime dateOfCreating { get; set; }
        public virtual List<CakeCakeBase> CakeBase { set; get; } = new List<CakeCakeBase>();
        public virtual List<CreamCake> Cream { set; get; } = new List<CreamCake>();
        public virtual List<FillingCake> Fruit { set; get; } = new List<FillingCake>();
        public virtual List<DecorCake> Decor { set; get; } = new List<DecorCake>();
        public virtual List<CoatingCake> Coating { set; get; } = new List<CoatingCake>();
        public virtual List<OrderBody> OrderBodies { set; get; }

    }
}

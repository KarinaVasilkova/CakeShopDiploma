using ShopWebApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class CoatingCake
    {
        public int? CakeId { get; set; }
        public Cake Cake { get; set; }
        public int? CakeCoatingId { get; set; }
        public cakeCoating CakeCoating { get; set; }
    }
}

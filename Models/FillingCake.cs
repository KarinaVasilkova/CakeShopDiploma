using ShopWebApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class FillingCake
    {
        public int? CakeId { get; set; }
        public Cake Cake { get; set; }
        public int? CakeFillingId { get; set; }
        public cakeFilling CakeFilling { get; set; }
    }
}

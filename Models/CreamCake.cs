using ShopWebApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class CreamCake
    {
        public int? CakeId { get; set; }
        public Cake Cake { get; set; }
        public int? CakeCreamId { get; set; }
        public cakeCream CakeCream { get; set; }
    }
}

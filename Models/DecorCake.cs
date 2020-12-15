using ShopWebApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class DecorCake
    {
        public int? CakeId { get; set; }
        public Cake Cake { get; set; }
        public int? CakeDecorationId { get; set; }
        public cakeDecoration CakeDecoration { get; set; }
    }
}

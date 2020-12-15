using ShopWebApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class CakeCakeBase
    {
        public int? CakeId { get; set; }
        public Cake Cake { get; set; }
        public int? CakeBaseId { get; set; }
        public cakeBase CakeBase { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Model.Entities
{
    public class Delivery
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public ushort Price { set; get; }
        public virtual List<Order> Orders { set; get; }

    }
}

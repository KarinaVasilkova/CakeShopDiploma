using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Model.Entities
{
    public class OrderBody
    {
        public int Id { set; get; }
        public int OrderID { set; get; }
        public virtual Order Order { set; get; }
        public int CakeID { set; get; }
        public virtual Cake Cake { set; get; }
        public int Amount { set; get; }

    }
}

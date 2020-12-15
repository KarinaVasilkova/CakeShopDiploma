using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Model.Entities
{
    public class OrderProgress
    {
        public int Id { set; get; }
        public int OrderID { set; get; }
        public virtual Order Order { set; get; }
        public DateTime Dateofdelivery { set; get; }
        public bool Ready { set; get; }

    }
}

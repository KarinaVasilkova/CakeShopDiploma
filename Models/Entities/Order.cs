using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Model.Entities
{
    public class Order
    {
        public int Id { set; get; }
        public int Number { set; get; }
        public int ClientID { set; get; }
        public virtual Client Client { set; get; }
        public int DeliveryID { set; get; }
        public virtual Delivery Delivery { set; get; }
        public DateTime Dateoforder { set; get; }
        public DateTime Dateofdelivery { set; get; }
        public int Sum { set; get; }
        public int Prepayment { set; get; }
        public bool Prepaymenttrue { set; get; }
        public int Discount { set; get; }
        public virtual List<OrderBody> Orderbodies { set; get; }
        public virtual List<OrderProgress> Orderprogreses { set; get; }
    }
}

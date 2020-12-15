using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Model.Entities
{
    public class Client
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public long Phone { set; get; }
        public string Address { set; get; }
        public int Prepayment { set; get; }
        public string Email { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public virtual List<Order> Orders { set; get; }   
    }
}

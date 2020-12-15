using ShopWebApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.ViewModels
{
    public class PersonalViewModel
    {
        public IEnumerable<cakeCream> cakeCream { get; set; }
        public IEnumerable<cakeBase> cakeBase { get; set; }
        public IEnumerable<cakeDecoration> cakeDecoration { get; set; }
        public IEnumerable<cakeFilling> cakeFilling { get; set; }
        public IEnumerable<cakeCoating> cakeCoating { get; set; }
    }

    public class PersonalCake
    {
        public Cake Cake { get; set; }
        public IEnumerable<cakeCream> cakeCream { get; set; }
        public IEnumerable<cakeBase> cakeBase { get; set; }
        public IEnumerable<cakeDecoration> cakeDecoration { get; set; }
        public IEnumerable<cakeFilling> cakeFilling { get; set; }
        public IEnumerable<cakeCoating> cakeCoating { get; set; }
    }
}

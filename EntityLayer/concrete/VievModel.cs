using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.concrete
{
   public class VievModel
    {
        public IEnumerable<Address> AddressS { get; set; }
        public IEnumerable<Customer> CustomerS { get; set; }
        public IEnumerable<Product> ProductS { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.concrete
{
    public partial class Model
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public Product Product { get; set; }
    }
}

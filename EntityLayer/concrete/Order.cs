using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.concrete
{
   public class Order
    {
        [Key]
        public int OrderId { get; set; }
     
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Required(ErrorMessage = "Please enter Number")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please enter Price")]
        public decimal Price { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

        public int Id { get; set; }
        public int AddressId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Address Address { get; set; }

    }
}

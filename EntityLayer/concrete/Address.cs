using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.concrete
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Please enter Addres")]
        public string AddressLine { get; set; }
        [Required(ErrorMessage = "Please enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter City Code")]
        public string CityCode { get; set; }
      
       


    }
}

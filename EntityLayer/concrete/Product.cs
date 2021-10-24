using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer.concrete
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter ImageUrl")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

    }
}

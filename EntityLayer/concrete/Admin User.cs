﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.concrete
{
   public class Admin_User
    {
        [Key]
        public int Id { get; set; }
        public string UName { get; set; }
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please enter Username")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Please enter Password")]
        public string PassWord { set; get; }

        public bool RememberMe { set; get; }
    }
}
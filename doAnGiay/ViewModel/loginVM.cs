using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace doAnGiay.ViewModel
{
    public class loginVM
    {

        [Required(ErrorMessage = "Username can't be blank")]
        public string UserName { get; set; }
        [Required (ErrorMessage ="Password can't be plank")]
        public string Password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace doAnGiay.ViewModel
{
    public class RegiterVM
    {
        [Required(ErrorMessage ="Username can't be blank")]
        public string UserName { get; set; }
        [Required ]
        public string Password { get; set; }
        [Required ]
        [Compare("Password", ErrorMessage ="PassWord and confirm password don't match")]

        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage ="Ivalid Email")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }


    }
}
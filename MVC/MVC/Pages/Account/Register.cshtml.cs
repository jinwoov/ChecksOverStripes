using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC.Models.Interface;

namespace MVC.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterInfo UserInfo { get; set; }

        

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return null;
        }

        public class RegisterInfo
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LName { get; set; }
            
            [Required]
            [Display(Name = "Favorite jordan series")]
            public int JordanSeries { get; set; }

            [Required]
            [StringLength(12, ErrorMessage = "The {0} must be at least {2} and max of {1} characters long", MinimumLength = 7)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Password does not match")]
            public string ConfirmPassword { get; set; }
        }
    }

    
}

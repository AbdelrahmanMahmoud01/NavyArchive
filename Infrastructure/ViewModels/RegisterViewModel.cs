using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Remote(action: "IsEmailInUse", controller: "Register")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        //[Required]
        public int OfficerId { get; set; }
        //[Required]
        public int DepartmentId { get; set; }
    }
}

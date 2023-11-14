using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoderzPro2.Models.ViewModels
{
    public class RegisterViewModel
    {
        [MinLength(3,ErrorMessage ="Min Length 3 Char")]
        [MaxLength(30,ErrorMessage ="Max Length 30 Char")]
        [Required(ErrorMessage = "Please Enter Full Name")]
        [DisplayName("Full Name")]
        public  string FullName { get; set; }
        [Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password ")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Confirm Not match")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [EmailAddress]
        [Required]
        [Compare("Email",ErrorMessage ="Email and Confirm email not match")]
        public string ConfirmEmail { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
      //  public Role Role { get; set; }
    }
}

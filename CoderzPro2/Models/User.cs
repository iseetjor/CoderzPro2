using CoderzPro2.Models.SharedProp;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoderzPro2.Models
{
    public class User : CommonProp
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}

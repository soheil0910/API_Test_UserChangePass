using System.ComponentModel.DataAnnotations;

namespace API_Test_UserChangePass.Models
{
    public class UserModel
    {


        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}

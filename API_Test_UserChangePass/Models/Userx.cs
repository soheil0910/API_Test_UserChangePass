using System.ComponentModel.DataAnnotations;

namespace API_Test_UserChangePass.Models
{
    public class Userx
    {




        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]        
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        
     
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string? Password_Test { get; set; }



        [MaxLength(300)]
        public string? Email { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }












    }
}

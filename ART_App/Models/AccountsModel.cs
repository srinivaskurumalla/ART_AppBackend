using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ART_App.Models
{
    public class SignUpModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the Name")]
        [MaxLength(50)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should be minimum of 3 characters and maximum of 50 characters")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the Email Address")]
        [EmailAddress(ErrorMessage = "please enter a valid email address")]
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        [Required(ErrorMessage = "Please enter the Password")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Password should be min of 4 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string EmpId { get; set; }
        public ICollection<ProjectsBRModel> ProjectsBRModels { get; set; }


    }

    public class Login
    {


        [Required(ErrorMessage = "Please enter the Email Address")]
        [EmailAddress(ErrorMessage = "please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the Password")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Password is too short.")]
        [DataType(DataType.Password)]
       
        public string Password { get; set; }

      


    }
}

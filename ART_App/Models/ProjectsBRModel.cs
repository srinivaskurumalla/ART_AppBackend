using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ART_App.Models
{
    [Index(nameof(ProjectName), IsUnique = true)]
    public class ProjectsBRModel
    {
        public int Id { get; set; }

        public string ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }

        [ForeignKey("AccountsBRModel")]
        public int AccountId { get; set; }
        public AccountsBRModel AccountsBRModel { get; set; }

        [ForeignKey("SignUpModel")]
        public int EmployeeId { get; set; }
        public SignUpModel SignUpModel { get; set; }

        public int Total_Positions { get; set; }

      
        public string Added_Modified_By { get; set; }


    }
}

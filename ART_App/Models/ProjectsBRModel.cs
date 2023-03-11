using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ART_App.Models
{
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

        public int No_Of_Positions { get; set; }

        public DateTime ApprovedDate { get; set; }

        public string Grade { get; set; }
        public string SkillSetRequired { get; set; }

        public string Status { get; set; }
        public string JobDescription { get; set; }




    }
}

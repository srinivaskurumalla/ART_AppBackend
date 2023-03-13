using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ART_App.Models
{
    //[Index(nameof(DomainName), IsUnique = true)]

    public class DomainsModel 
    {
        public int Id { get; set; }
        [Required]
        public string DomainName { get; set; }

       // public string ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }

       /* [ForeignKey("AccountsBRModel")]
        public int AccountId { get; set; }
        public AccountsBRModel AccountsBRModel { get; set; }*/

        [ForeignKey("SignUpModel")]
        public int EmployeeId { get; set; }
        public SignUpModel SignUpModel { get; set; }

        public int No_Of_Positions { get; set; }


        public string Added_Modified_By { get; set; }

        [ForeignKey("ProjectsBRModel")]
        public int ProjectFkId { get; set; }
        public ProjectsBRModel ProjectsBRModel { get; set; }
        public DateTime ApprovedDate { get; set; }

        public string Grade { get; set; }
        public string SkillSetRequired { get; set; }

        public string Status { get; set; }
        public string JobDescription { get; set; }
        public int Age { get; set; }


    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ART_App.Models
{
    public class ProjectsBRModel
    {
        public int Id { get; set; }

        [Required]
        public string ProjectName { get; set; }

        
        public int AccountsBRModelId { get; set; }
        public AccountsBRModel AccountsBRModel { get; set; }

        public DateTime ApprovedDate { get; set; }

        public string Grade { get; set; }
        public string SkillSetRequired { get; set; }

        public string Status { get; set; }
        public string JobDescription { get; set; }




    }
}

using System;

namespace ART_App.Models
{
    public class MasterBRModel 
    {
        public int Id { get; set; }
        public int ProjectsBRModelId { get; set; }
        public ProjectsBRModel ProjectsBRModel { get; set; }
      /*  public int AccountsBRModelId { get; set; }
        public AccountsBRModel AccountsBRModel { get; set; }
*/

        public string CandidateName { get; set; }
        public string Int_Ext { get; set; }
        public string Location { get; set; }
        public string Source { get; set; }
        public string Grade { get; set; }
        public string SkillSetRequired { get; set; }

        public string JobDescription { get; set; }
        public int Age { get; set; }

        public DateTime ScreeningDate { get; set; }
        public string ScreeningResult { get; set; }
        public DateTime L1_Eval_Date { get; set; }
        public string L1_Eval_Result { get; set;}

        public DateTime Client_Eval_Date { get; set; }
        public string Client_Eval_Result { get; set; }

        public DateTime Manager_Eval_Date { get; set; }
        public string Manager_Eval_Result { get; set; }

        public string Status { get; set; }
        public string Eval_Comments { get; set; }

    }
}

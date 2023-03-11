using System.ComponentModel.DataAnnotations;

namespace ART_App.Models
{
    public class AccountsBRModel
    {
        public int Id { get; set; }

        [Required]
        public string AccountName { get; set; }
        public string AccountId { get; set; }

    }
}

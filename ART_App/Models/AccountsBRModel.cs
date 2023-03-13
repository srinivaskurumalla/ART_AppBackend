using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ART_App.Models
{
    [Index(nameof(AccountName), IsUnique = true)]

    public class AccountsBRModel
    {
        public int Id { get; set; }

        public string AccountName { get; set; }
        public string AccountId { get; set; }

    }
}

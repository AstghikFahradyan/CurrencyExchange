using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Currencyexchange.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;

        [JsonIgnore]
        public string? PasswordHash { get; set; }= string.Empty;    
    }
}

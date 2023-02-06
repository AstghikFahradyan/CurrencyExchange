using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Currencyexchange.Models
{
  
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public string ExchangeType { get; set; } = string.Empty;
        public string ExchangeKey { get; set; }  = string.Empty;    
        public float ExchangeValue { get; set; }
        public float AmountFor { get; set; }
        public float AmountTo { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

using Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace DB.Entities
{
    public class Account
    {
        [Key]
        public string? NumberAccount { get; set; }
        public TypeAccount AccountType { get; set; }
        public decimal? InitialBalance { get; set; }
        public bool Status { get; set; }

        //foreigns
        public virtual Client? Client { get; set; }
        public virtual ICollection<Transactions>? Transactions { get; set; }
    }
}

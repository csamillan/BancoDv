using Shared.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Entities
{
    public class Account
    {
        [Key]
        public string? NumberAccount { get; set; }
        public TypeAccount AccountType { get; set; }
        public decimal? InitialBalance { get; set; }
        public bool Status { get; set; }
        public string? IdentityDocument { get; set; }

        //foreigns
        [ForeignKey(nameof(IdentityDocument))]
        public virtual Client? Client { get; set; }
        public virtual ICollection<Transactions>? Transactions { get; set; }
    }
}

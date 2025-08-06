using Shared.Enum;

namespace Core.Module.Accounts.Dtos
{
    public class AccountSaveDto
    {
        public string? NumberAccount { get; set; }
        public TypeAccount AccountType { get; set; }
        public decimal? InitialBalance { get; set; }
        public bool Status { get; set; }
        public string? IdentityDocument { get; set; }
    }
}

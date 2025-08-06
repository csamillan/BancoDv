using Shared.Enum;

namespace Core.Module.Transaction.Dtos
{
    public class TransactionSaveDto
    {
        public DateTime Date { get; set; }
        public TypeTransaccion TypeMovement { get; set; }
        public decimal Value { get; set; }
        public string? AccountNumberAccount { get; set; }
    }
}

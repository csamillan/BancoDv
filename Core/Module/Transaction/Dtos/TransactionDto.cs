using Shared.Enum;

namespace Core.Module.Transaction.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TypeTransaccion TypeMovement { get; set; }
        public decimal Value { get; set; }
        public decimal Sald { get; set; }
        public string? AccountNumberAccount { get; set; }
    }
}

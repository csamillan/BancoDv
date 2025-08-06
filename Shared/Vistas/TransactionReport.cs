namespace Shared.Vistas
{
    public class TransactionReport
    {
        public DateTime Date { get; set; }
        public string? Name { get; set; }
        public string? AccountNumber { get; set; }
        public string? Type { get; set; }
        public decimal InitialSald { get; set; }
        public bool Status { get; set; }
        public decimal Transactions { get; set; }
        public decimal CurrectSald { get; set; }
    }
}

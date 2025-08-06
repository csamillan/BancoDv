namespace Shared.Vistas
{
    public class ResponseReport
    {
        public IList<TransactionReport>? Transactions { get; set; }
        public string? Base64Report { get; set; }
    }
}

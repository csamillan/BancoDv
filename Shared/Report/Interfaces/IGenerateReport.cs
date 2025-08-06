using Shared.Vistas;

namespace Shared.Report.Interfaces
{
    public interface IGenerateReport
    {
        string GenerateTransactionReportPdfBase64(List<TransactionReport> transactions);
    }
}

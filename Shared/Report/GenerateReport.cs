using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using Shared.Vistas;
using Shared.Report.Interfaces;

namespace Shared.Report
{
    public class GenerateReport : IGenerateReport
    {
        public string GenerateTransactionReportPdfBase64(List<TransactionReport> transactions)
        {
            using var memoryStream = new MemoryStream();
            using var writer = new PdfWriter(memoryStream);
            using var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            document.SetFont(font);

            // Título
            document.Add(new Paragraph("Reporte de Transacciones")
                .SetFontSize(16)
                .SetFont(boldFont)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetMarginBottom(20));

            // Tabla
            var table = new Table(UnitValue.CreatePercentArray(new float[] { 10, 15, 15, 10, 10, 10, 10, 10 })).UseAllAvailableWidth();

            // Encabezados
            string[] headers = { "Fecha", "Cliente", "Cuenta", "Tipo", "Saldo Inicial", "Estado", "Movimiento", "Saldo Disp." };
            foreach (var header in headers)
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(header).SetFont(boldFont)));
            }

            // Celdas
            foreach (var t in transactions)
            {
                table.AddCell(t.Date.ToString("yyyy-MM-dd"));
                table.AddCell(t.Name ?? "");
                table.AddCell(t.AccountNumber ?? "");
                table.AddCell(t.Type ?? "");
                table.AddCell(t.InitialSald.ToString("F2"));
                table.AddCell(t.Status.ToString());
                table.AddCell(t.Transactions.ToString("F2"));
                table.AddCell(t.CurrectSald.ToString("F2"));
            }

            document.Add(table);
            document.Close();

            return Convert.ToBase64String(memoryStream.ToArray());
        }
    
    }
}

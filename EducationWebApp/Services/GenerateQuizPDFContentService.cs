
namespace EducationWebApp.Services
{
    public class GenerateQuizPDFContentService
    {
        // Add Ilogger for logging

        public byte[] GenerateQuizPDFContent(string subject, string formattedQuizContent)
        {
            // Add null check for subject and formattedQuizContent
            // Add try catch to pdf generation logic
            // Instead of using iText.Kernel.Pdf namespace try to import the namespace at the start with using iText.Kernel.Pdf;using iText.Layout; using iText.Layout.Element;

            using var memoryStream = new MemoryStream();
            var writer = new iText.Kernel.Pdf.PdfWriter(memoryStream);
            var pdfDocument = new iText.Kernel.Pdf.PdfDocument(writer);
            var document = new iText.Layout.Document(pdfDocument);

          
            document.Add(new iText.Layout.Element.Paragraph($"Quiz on {subject}")
                .SetFontSize(20));

         
            document.Add(new iText.Layout.Element.Paragraph(formattedQuizContent)
                .SetFontSize(12));

         
            document.Close();

            return memoryStream.ToArray();
        }
    }
}

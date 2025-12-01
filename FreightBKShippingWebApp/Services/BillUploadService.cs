using System.Net.Http.Headers;
using System.Text.Json;

namespace FreightBKShippingWebApp.Services
{
    public class BillUploadService
    {
        private readonly ApiClient _api;

        public BillUploadService(ApiClient api)
        {
            _api = api;
        }

        /// <summary>
        /// Upload bill PDF file and returns uploaded file URL.
        /// </summary>
        public async Task<string?> UploadBillPdfAsync(
     byte[] fileBytes,
     string fileName,
     string billId,
     string billType)
        {
            try
            {
                using var content = new MultipartFormDataContent();
                using var fileContent = new ByteArrayContent(fileBytes);

                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/pdf");
                content.Add(fileContent, "file", fileName);

                // Make billType safe (same logic as certType)
                var safeBillType = string.Concat(billType.Split(Path.GetInvalidFileNameChars()))
                                         .Replace(" ", "_");

                var url = $"api/BillUpload/upload-pdf-file?billId={billId}&billType={safeBillType}";

                // Generic POST call (same logic)
                var responseJson = await _api.PostAsync<string>(url, content);

                if (string.IsNullOrEmpty(responseJson))
                    return null;

                // Check JSON response { "url": "..." }
                try
                {
                    using var doc = JsonDocument.Parse(responseJson);
                    if (doc.RootElement.TryGetProperty("url", out var urlElement))
                        return urlElement.GetString();
                }
                catch
                {
                    // ignore → could be plain URL
                }

                // fallback
                return responseJson;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error uploading Bill PDF: {ex.Message}");
                return null;
            }
        }

    }
}

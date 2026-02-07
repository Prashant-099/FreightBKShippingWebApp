//using System.Net.Http.Headers;
//using System.Text.Json;

//namespace FreightBKShippingWebApp.Services
//{
//    public class BillUploadService
//    {
//        private readonly ApiClient _api;

//        public BillUploadService(ApiClient api)
//        {
//            _api = api;
//        }

//        /// <summary>
//        /// Upload bill PDF file and returns uploaded file URL.
//        /// </summary>
//        public async Task<string?> UploadBillPdfAsync(
//     byte[] fileBytes,
//     string fileName,
//     string billId,
//     string billType)
//        {
//            try
//            {
//                using var content = new MultipartFormDataContent();
//                using var fileContent = new ByteArrayContent(fileBytes);

//                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/pdf");
//                content.Add(fileContent, "file", fileName);

//                // Make billType safe (same logic as certType)
//                var safeBillType = string.Concat(billType.Split(Path.GetInvalidFileNameChars()))
//                                         .Replace(" ", "_");

//                var url = $"api/BillUpload/upload-pdf-file?billId={billId}&billType={safeBillType}";

//                // Generic POST call (same logic)
//                var responseJson = await _api.PostAsync<string>(url, content);

//                if (string.IsNullOrEmpty(responseJson))
//                    return null;

//                // Check JSON response { "url": "..." }
//                try
//                {
//                    using var doc = JsonDocument.Parse(responseJson);
//                    if (doc.RootElement.TryGetProperty("url", out var urlElement))
//                        return urlElement.GetString();
//                }
//                catch
//                {
//                    // ignore → could be plain URL
//                }

//                // fallback
//                return responseJson;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"❌ Error uploading Bill PDF: {ex.Message}");
//                return null;
//            }
//        }

//    }
//}


using System.Net.Http.Headers;
using System.Text.Json;

namespace FreightBKShippingWebApp.Services
{
    public class FileUploadService
    {
        private readonly ApiClient _api;

        public FileUploadService(ApiClient api)
        {
            _api = api;
        }

        // ===================== UPLOAD =====================

        public async Task<FileUploadResponse?> UploadFileAsync(
            byte[] fileBytes,
            string fileName,
            string category,
            string? subCategory = null,
            string? referenceId = null)
        {
            using var content = new MultipartFormDataContent();
            using var fileContent = new ByteArrayContent(fileBytes);

            var extension = Path.GetExtension(fileName).ToLower();
            fileContent.Headers.ContentType =
                MediaTypeHeaderValue.Parse(GetContentType(extension));

            content.Add(fileContent, "file", fileName);
            content.Add(new StringContent(category), "category");

            if (!string.IsNullOrWhiteSpace(subCategory))
                content.Add(new StringContent(subCategory), "subCategory");

            if (!string.IsNullOrWhiteSpace(referenceId))
                content.Add(new StringContent(referenceId), "referenceId");

            var responseJson =
                await _api.PostAsync<string>("api/FileUpload/upload", content);

            return string.IsNullOrEmpty(responseJson)
                ? null
                : JsonSerializer.Deserialize<FileUploadResponse>(
                    responseJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // ===================== LIST FROM DB =====================

        public async Task<List<DocumentDto>> GetDocumentsAsync(
            string category,
            string? referenceId = null)
        {
            var url = $"api/FileUpload/documents?category={Uri.EscapeDataString(category)}";

            if (!string.IsNullOrWhiteSpace(referenceId))
                url += $"&referenceId={Uri.EscapeDataString(referenceId)}";

            return await _api.GetFromJsonAsync<List<DocumentDto>>(url)
                   ?? new List<DocumentDto>();
        }

        // ===================== DELETE =====================

        public async Task<bool> DeleteDocumentAsync(long documentId)
        {
            var url = $"api/FileUpload/delete?documentId={documentId}";
            var result = await _api.DeleteAsync<DeleteResponse>(url);
            return result?.Success ?? false;
        }

        // ===================== HELPERS =====================

        private string GetContentType(string ext) => ext switch
        {
            ".pdf" => "application/pdf",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".doc" => "application/msword",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ".xls" => "application/vnd.ms-excel",
            ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            ".txt" => "text/plain",
            ".csv" => "text/csv",
            ".zip" => "application/zip",
            ".rar" => "application/x-rar-compressed",
            _ => "application/octet-stream"
        };
    }

    // ===================== DTOs =====================

    public class FileUploadResponse
    {
        public bool Success { get; set; }
        public long DocumentId { get; set; }
        public string Url { get; set; }
        public string BlobName { get; set; }
        public string ContainerName { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }
        public string Category { get; set; }
        public string? SubCategory { get; set; }
        public string? ReferenceId { get; set; }
    }

    public class DocumentDto
    {
        public long DocumentId { get; set; }
        public string Category { get; set; }
        public string? SubCategory { get; set; }
        public string OriginalFileName { get; set; }
        public string BlobUrl { get; set; }
        public long FileSizeBytes { get; set; }
        public string ContentType { get; set; }
        public DateTime UploadedAt { get; set; }
    }

    public class DeleteResponse
    {
        public bool Success { get; set; }
    }
}

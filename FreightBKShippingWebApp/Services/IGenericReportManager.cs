namespace FreightBKShippingWebApp.Services
{
    public interface IGenericReportManager
    {
        // 🔹 Core generator (Preview / Download / WhatsApp all use this)
        Task<(byte[] pdfBytes, string fileName)> GeneratePdfAsync<T, TDto>(
            List<T> items,
            Func<T, Task<int>> getReportIdAsync,
            Func<T, Task<TDto?>> getDtoAsync,
            Func<T, string> getDocType,     // 🔹 Added
            string fileName = "Report.pdf")
            where TDto : class;

        // 🔹 Download directly
        Task DownloadAsync<T, TDto>(
            List<T> items,
            Func<T, Task<int>> getReportIdAsync,
            Func<T, Task<TDto?>> getDtoAsync,
            Func<T, string> getDocType,     // 🔹 Added
            string fileName = "Report.pdf")
            where TDto : class;

        // 🔹 Preview directly
        Task PreviewAsync<T, TDto>(
            List<T> items,
            Func<T, Task<int>> getReportIdAsync,
            Func<T, Task<TDto?>> getDtoAsync,
            Func<T, string> getDocType,     // 🔹 Added
            string fileName = "Report.pdf")
            where TDto : class;
    }
}

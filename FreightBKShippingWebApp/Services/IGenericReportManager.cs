namespace FreightBKShippingWebApp.Services
{
    public interface IGenericReportManager
    {
        Task PrintAsync<T, TDto>(
            List<T> items,
            Func<T, Task<int>> getReportIdAsync,
            Func<T, Task<TDto?>> getDtoAsync)
            where TDto : class;

        Task DownloadAsync<T, TDto>(
            List<T> items,
            Func<T, Task<int>> getReportIdAsync,
            Func<T, Task<TDto?>> getDtoAsync,
            bool sendViaWhatsapp = false)
            where TDto : class;
    }



}

namespace FreightBKShippingWebApp.Services
{
    public class ConfirmationDialogService
    {
        public Func<string, Task<bool>> OnShow { get; set; }


        public async Task<bool> ShowAsync(string message)
        {
            if (OnShow != null)
            {
                return await OnShow.Invoke(message);
            }
            return false;
        }
    }

}

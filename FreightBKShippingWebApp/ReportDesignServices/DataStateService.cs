namespace FreightBKShippingWebApp.ReportDesignServices
{
    public class DataStateService
    {
        public event Func<Task>? OnChange;

        public async Task NotifyDataChanged()
        {
            if (OnChange != null)
            {
                await OnChange.Invoke();
            }
        }
    }
}

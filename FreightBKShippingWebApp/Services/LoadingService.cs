namespace FreightBKShippingWebApp.Services
{
    public class LoadingService
    {
        public event Action? OnChange;
        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            private set
            {
                _isLoading = value;
                OnChange?.Invoke(); // Notify UI components
            }
        }
        public void Show() => IsLoading = true;
        public void Show(string v) => IsLoading = true;
        public void Hide() => IsLoading = false;
    }
}

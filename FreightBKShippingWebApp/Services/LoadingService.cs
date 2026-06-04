
namespace FreightBKShippingWebApp.Services
{
    public class LoadingService
    {
        public event Action? OnChange;
        private bool _isLoading;
        private Func<Func<Task>, Task>? _invokeAsync;
        public bool IsLoading
        {
            get => _isLoading;
            private set
            {
                _isLoading = value;
                OnChange?.Invoke(); // Notify UI components
            }
        }

        /// <summary>
        /// Sets the dispatcher for thread-safe UI updates in Blazor.
        /// Call this once during component initialization.
        /// </summary>
        public void SetInvoker(Func<Func<Task>, Task> invokeAsync) => _invokeAsync = invokeAsync;



        //public void Show() => IsLoading = true;
        //public void Show(string v) => IsLoading = true;
        //public void Hide() => IsLoading = false;
        public void Show() => SetLoading(true);

        public void Show(string v) => SetLoading(true);

        public void Hide() => SetLoading(false);

        private void SetLoading(bool value)
        {
            if (_invokeAsync != null)
            {
                // Marshal the state change to the Blazor renderer
                _ = _invokeAsync.Invoke(() =>
                {
                    _isLoading = value;
                    OnChange?.Invoke();
                    return Task.CompletedTask;
                });
            }
            else
            {
                // Fallback for non-Blazor contexts or before invoker is registered
                _isLoading = value;
                OnChange?.Invoke();
            }
        }
    }
}

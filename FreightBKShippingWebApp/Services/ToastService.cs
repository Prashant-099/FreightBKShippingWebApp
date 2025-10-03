namespace FreightBKShippingWebApp.Services
{

    //public class ToastService
    //{
    //    public event Action<ToastLevel, string, string>? OnShow;

    //    public void ShowToast(ToastLevel level, string message, string? heading = "")
    //    {
    //        OnShow?.Invoke(level, message, heading ?? string.Empty);
    //    }

    //    public void ShowSuccess(string message, string? heading = "Success") =>
    //        ShowToast(ToastLevel.Success, message, heading);

    //    public void ShowError(string message, string? heading = "Error") =>
    //        ShowToast(ToastLevel.Error, message, heading);

    //    public void ShowInfo(string message, string? heading = "Info") =>
    //        ShowToast(ToastLevel.Info, message, heading);

    //    public void ShowWarning(string message, string? heading = "Warning") =>
    //        ShowToast(ToastLevel.Warning, message, heading);
    //}

    //public enum ToastLevel
    //{
    //    Info,
    //    Success,
    //    Warning,
    //    Error
    //}

    using DevExpress.Blazor;

    public class ToasteService
    {
        private readonly IToastNotificationService _toast;

        public ToasteService(IToastNotificationService toast)
        {
            _toast = toast;
        }

        public void Success(string text, string? title = "Success")
        {
            _toast.ShowToast(new ToastOptions
            {
                ProviderName = "GlobalToast",
                Title = title,
                Text = text,
                RenderStyle = ToastRenderStyle.Success
            });
        }

        public void Error(string text, string? title = "Error")
        {
            _toast.ShowToast(new ToastOptions
            {
                ProviderName = "GlobalToast",
                Title = title,
                Text = text,
                RenderStyle = ToastRenderStyle.Danger
            });
        }

        public void Info(string text, string? title = "Info")
        {
            _toast.ShowToast(new ToastOptions
            {
                ProviderName = "GlobalToast",
                Title = title,
                Text = text,
                RenderStyle = ToastRenderStyle.Info
            });
        }

        public void Warning(string text, string? title = "Warning")
        {
            _toast.ShowToast(new ToastOptions
            {
                ProviderName = "GlobalToast",
                Title = title,
                Text = text,
                RenderStyle = ToastRenderStyle.Warning
            });
        }
    }
}

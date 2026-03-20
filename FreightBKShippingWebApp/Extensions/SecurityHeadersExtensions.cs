namespace FreightBKShippingWebApp.Extensions
{
    public static class SecurityHeadersExtensions
    {
        public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                // 1. Content Security Policy (Optimized)
                // Removed broad 'https:' to satisfy ZAP's wildcard warning
                context.Response.Headers["Content-Security-Policy"] =
                    "default-src 'self'; " +
                    "script-src 'self' 'unsafe-inline' 'unsafe-eval' https://cdn.jsdelivr.net; " +
                    "style-src 'self' 'unsafe-inline' https://fonts.googleapis.com https://cdn.jsdelivr.net; " +
                    "img-src 'self' data: blob: https://freightbookstorage.blob.core.windows.net; " +
                    "media-src 'self' blob: https://freightbookstorage.blob.core.windows.net; " +
                    "font-src 'self' data: https://fonts.gstatic.com https://cdn.jsdelivr.net; " +
                    "connect-src 'self' wss:; " + // 'wss:' is required for Blazor Server SignalR
                    "frame-src 'self' https://freightbookstorage.blob.core.windows.net; " +
                    "form-action 'self'; " + // Prevents form data from being sent to other domains
                    "upgrade-insecure-requests;"; // Forces browser to use HTTPS for any HTTP links

                // 2. Prevent Multiple X-Frame-Options
                if (!context.Response.Headers.ContainsKey("X-Frame-Options"))
                {
                    context.Response.Headers["X-Frame-Options"] = "SAMEORIGIN";
                }

                // 3. Standard Security Headers
                context.Response.Headers["X-Content-Type-Options"] = "nosniff";
                context.Response.Headers["Referrer-Policy"] = "strict-origin-when-cross-origin";

                // 4. Permissions Policy (Modern replacement for Feature-Policy)
                // Disables camera/microphone/geolocation unless needed
                context.Response.Headers["Permissions-Policy"] = "camera=(), microphone=(), geolocation=()";

                await next();
            });

            return app;
        }
    }
}

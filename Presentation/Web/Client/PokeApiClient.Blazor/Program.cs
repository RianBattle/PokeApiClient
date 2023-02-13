using Ardalis.GuardClauses;
using PokeApiClient.Blazor.Data;

public class PokeApiClientBlazorStartup {
    private WebApplication _app;

    public PokeApiClientBlazorStartup(string[] args, Action<IServiceCollection>? options) {
        WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
        ConfigureWebApplicationBuilder(builder, options);
        BuildWebApplication(builder);
    }

    private void ConfigureWebApplicationBuilder(WebApplicationBuilder? builder, Action<IServiceCollection>? options) {
        Guard.Against.Null(builder);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddSingleton<WeatherForecastService>();

        options?.Invoke(builder.Services);
    }

    private void BuildWebApplication(WebApplicationBuilder? builder) {
        Guard.Against.Null(builder);

        _app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!_app.Environment.IsDevelopment()) {
            _app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            _app.UseHsts();
        }

        _app.UseHttpsRedirection();

        _app.UseStaticFiles();

        _app.UseRouting();

        _app.MapBlazorHub();
        _app.MapFallbackToPage("/_Host");
    }

    public Task StartAsync() {
        return _app.RunAsync();
    }
}

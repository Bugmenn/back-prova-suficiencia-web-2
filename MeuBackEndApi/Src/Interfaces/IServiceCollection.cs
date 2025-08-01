using MeuBackEndApi.Src.AppService;
using MeuBackEndApi.Src.Interfaces;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IMensagemAppService, MensagemAppService>();
        return services;
    }
}
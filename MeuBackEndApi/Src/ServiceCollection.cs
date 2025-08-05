using MeuBackEndApi.Src.AppService;
using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Repositories;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioAppService, UsuarioAppService>();
        services.AddScoped<IComandaAppService, ComandaAppService>();
        services.AddScoped<ILoginAppService, LoginAppService>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IComandaRepository, ComandaRepository>();
        services.AddScoped<ILoginRepository, LoginRepository>();
        return services;
    }
}
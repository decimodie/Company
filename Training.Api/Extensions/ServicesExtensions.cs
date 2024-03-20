namespace Training.Api;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection Services)
    {
        Services.AddScoped<IStore, Store<Entity>>();
        Services.AddScoped(typeof(IStore<>), typeof(Store<>));
        Services.AddScoped<IProductServices, ProductServices>();
        return Services;
    }

    /// <summary>
    ///     Configura mediante Option Pattern las configuraciones generales de Company.
    /// </summary>
    /// <param name="Services">
    ///     Objeto contenedor IoC de todas las dependencias usadas por Company.
    /// </param>
    /// <returns>
    ///     Regresa el objeto contenedor IoC para habilitar las llamada en cadenas.
    /// </returns>
    public static IServiceCollection AddCompanyOptions(this IServiceCollection Services)
    {
        Services.AddOptions<CompanyOptions>()
            .Configure<IConfiguration>(static (Options, Configuration) =>
            {
                Configuration.GetSection("CompanyOptions").Bind(Options);

                Options.ConnectionString = Configuration.GetConnectionString("ConnectionString")!;

                if (string.IsNullOrEmpty(Options.ConnectionString))
                {
                    Options.ConnectionString = Environment.GetEnvironmentVariable("ConnectionString")!;
                }
            });

        Services.Configure<ApiBehaviorOptions>(static Options => { });
        return Services;
    }
}

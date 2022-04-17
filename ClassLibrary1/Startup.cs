using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public Startup(IConfiguration configuration, IWebHostEnvironment env, IServiceProvider serviceProvider, ILogger<Startup> logger)
    {
        HostingEnvironment = env;
        Configuration = configuration;
        _serviceProvider = serviceProvider;
        _logger = logger;



        //AppSettings
        _appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
        _azureSettings = Configuration.GetSection("AzureSettings").Get<AzureSettings>();

        _logger.LogDebug("Startup::Constructor::Settings loaded");
    }

    public void ConfigureServices(IServiceCollection services)
    {
        _logger.LogTrace("Startup::ConfigureServices");



        try
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));



            //We bind the appsettings.json configurations to make IOptions<> operational.



            services.Configure<AzureSettings>(Configuration.GetSection("AzureSettings"));
        }
}
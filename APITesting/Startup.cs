using Microsoft.AspNetCore.Builder;

namespace APITesting
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpClient();
            services.AddSingleton(sp => new HttpClient());
        }
    }
}

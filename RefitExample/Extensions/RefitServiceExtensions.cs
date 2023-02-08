using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Refit;
using RefitExample.Abstractions;
using RefitExample.Concretes;

namespace RefitExample.Extensions
{
    public static class RefitServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHeaderParameterService, HeaderParameterManager>();

            var jsonOptions = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                NullValueHandling = NullValueHandling.Include,
                Formatting = Formatting.Indented
            };

            jsonOptions.Converters.Add(new StringEnumConverter());

            var settings = new RefitSettings()
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(jsonOptions)
            };

            var url = configuration.GetValue<string>("RefitSettings:endpointUrl");

            services.AddRefitClient<ILoginService>()
            .ConfigureHttpClient((sp, c) =>
            {
                c.BaseAddress = new Uri(url);
                c.Timeout = TimeSpan.FromMinutes(2);
            });


            services.AddRefitClient<IPostsClient>().ConfigureHttpClient((sp, c) =>
            {
                c.BaseAddress = new Uri(url);
                c.Timeout = TimeSpan.FromSeconds(2);
                //Header da göndereceğin bilgiyi buradan gönderebilirsin.
                c.DefaultRequestHeaders.Add("Bearer", sp.GetService<IHeaderParameterService>().GetToken());
            });
        }
    }
}
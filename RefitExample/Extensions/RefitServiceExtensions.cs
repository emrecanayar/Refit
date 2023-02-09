using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
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

            //Proje içerisinde yer alan genel json yapısının özelliklerini buradan belirliyoruz.
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

            //İstek atacağımız end-pointin base url ini appsettings.json dosyasından okuma işlemi.

            var url = configuration.GetValue<string>("RefitSettings:endpointUrl");

            //Login Sevisi için gerekli olan Refit yapılandırılması bu şekilde olmalıdır.
            services.AddRefitClient<ILoginClient>()
            .ConfigureHttpClient((sp, c) =>
            {
                c.BaseAddress = new Uri(url);
                c.Timeout = TimeSpan.FromMinutes(2);
            });

            //Post servisi için gerekli olan Refit yapılandırılması bu şekilde olmalıdır.

            services.AddRefitClient<IPostsClient>().ConfigureHttpClient((sp, c) =>
            {
                c.BaseAddress = new Uri(url);
                c.Timeout = TimeSpan.FromSeconds(2);
                //Header da göndereceğin bilgiyi buradan gönderebilirsin.(Örnek olarak HeaderParameterService içerisinde yer alan token bilgisini ben buradaki post servisine istek atarken Bearer olarak Header da göndermek istiyorum. İşte bunu burada bu şekilde dinamik olarak gerçekleştirebiliriz.)
                c.DefaultRequestHeaders.Add("Bearer", sp.GetService<IHeaderParameterService>().GetToken());
            });
        }
    }
}
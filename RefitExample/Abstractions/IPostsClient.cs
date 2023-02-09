using Refit;
using RefitExample.Models;

namespace RefitExample.Abstractions
{
    /*
     
     Refit i kullanabilmek için istek yapacağımız yapıyı Client adında bir interface içerisinde tanımlıyoruz.
    https://jsonplaceholder.typicode.com/ sitesinde yer alan posts apisine burada bir GET isteği atıyoruz.
    Bunun için aşağıdaki metotu inceleyebiliriz.
     
     */

    //İstek yapacağımız end-point in Headers kısmında Content-Type:application/json olacağını bildiriyoruz.
    [Headers("Content-Type: application/json")]
    public interface IPostsClient
    {
        // https://jsonplaceholder.typicode.com/posts/ adresine bir Get isteği yapacağımızı bildiriyoruz. Burada bir metot oluşturuyoruz ve geri dönüş tipini de alacağı parametreyide burada belirtiyoruz. Daha sonra bu end-pointten gelen datayı nerede kullanacaksan bu interface i orada inject ederek kullanabiliriz.
        [Get("/posts/{postId}")] //GET isteği yapacağımızdan dolayı attiribure GET olarak ayarlıyoruz. (base end-pointi appsettings.json da tutuyoruz.) Genel konfigurasyon ayarları Extensions klasörü altında yer alan extended metot içerisinde tanımlıyoruz.
        Task<PostDto> GetPostById(int postId);
    }
}
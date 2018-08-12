using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MyMovieDb.App.Areas.Identity.IdentityHostingStartup))]
namespace MyMovieDb.App.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
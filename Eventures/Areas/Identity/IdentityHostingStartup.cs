using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Eventures.Areas.Identity.IdentityHostingStartup))]
namespace Eventures.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
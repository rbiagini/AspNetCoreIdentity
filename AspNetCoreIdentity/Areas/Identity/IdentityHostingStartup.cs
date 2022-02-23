using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AspNetCoreIdentity.Areas.Identity.IdentityHostingStartup))]
namespace AspNetCoreIdentity.Areas.Identity
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
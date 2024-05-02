using CurrieTechnologies.Razor.SweetAlert2;
using Entrega2.PGPIC.UI.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Entrega2.PGPIC.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddSweetAlert2();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7000") });
            builder.Services.AddScoped<IRepository, Repository>();
            await builder.Build().RunAsync();
        }
    }
}

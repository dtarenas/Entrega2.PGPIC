using Entrega2.PGPIC.API.Data;
using Entrega2.PGPIC.API.Helpers;
using Entrega2.PGPIC.Shared.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Entrega2.PGPIC.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddIdentity<User, IdentityRole>(x =>
            {
                x.User.RequireUniqueEmail = true;
                x.Password.RequireDigit = false;
                x.Password.RequiredUniqueChars = 6;
                x.Password.RequireUppercase = false;
                x.Password.RequireLowercase = false;

                x.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<PGPICContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddScoped<IUserHelper, UserHelper>();
            builder.Services.AddTransient<SeedDb>();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<PGPICContext>(opt => opt.UseSqlServer("name=PGPICConnection"));

            var app = builder.Build();

            SeedData(app);

            static void SeedData(WebApplication app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

                using (var scope = scopedFactory!.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<SeedDb>();
                    service!.SeedAsync().Wait();
                }

                // Configure the HTTP request pipeline.
               
                    app.UseSwagger();
                    app.UseSwaggerUI();
                

                app.UseHttpsRedirection();

                app.UseAuthentication();

                app.UseAuthorization();

                app.MapControllers();

                app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetIsOriginAllowed(origin => true)
                );

                app.Run();
            }
        }
    }
}
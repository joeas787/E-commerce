using E_Commerce.Domain.Contracts;
using E_Commerce.persistence.PersistenceService;
using E_Commerce.Service.Injection;
using System.Threading.Tasks;
namespace E_commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddPersistenceService(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddServices();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
           var scope= app.Services.CreateScope();
           var initializer =scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await initializer.initializerAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

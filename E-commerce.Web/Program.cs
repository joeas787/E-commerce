using E_commerce.Infrastructure.Service;
using E_commerce.Web.Exceptionhandler;
using E_commerce.Web.Middlewares;
using E_Commerce.Domain.Contracts;
using E_Commerce.persistence.PersistenceService;
using E_Commerce.Service.Contracts;
using E_Commerce.Service.Injection;
using E_Commerce.ServiceAbstraction;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
namespace E_commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //
            //
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddPersistenceService(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddServices();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddExceptionHandler<ExceptionHandlerEx>();
           // builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection(JWTOptions.SectionName));
            builder.Services.Configure<ApiBehaviorOptions>(o =>
            {

                o.InvalidModelStateResponseFactory = a =>
                {

                    var r = a.ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, x => x.Value.Errors.Select
                    (e => e.ErrorMessage).ToList());
                    var problem=new ProblemDetails {

                     Title="one or more vaild error",
                     Detail="Valid errors",
                     Status=StatusCodes.Status400BadRequest,
                        Extensions = { { "Errors",r} }



                    };

                    return new BadRequestObjectResult(problem);
                };



            });
            builder.Services.AddProblemDetails();
            builder.Services.AddAuthentication(options =>
            {
                
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
        .AddJwtBearer(options =>
        {
           
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "My-Api-Project",
                ValidAudience = "My-Api-Project",
                IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("MyApiProjectMyApiProjectMyApiProject"))


            };
        });
            var app = builder.Build();
           var scope= app.Services.CreateScope();
           var initializer =scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await initializer.initializerAsync();
            await initializer.initializerAuthAsync();
            // app.UseMiddleware<ExceptionHandler>();
            app.UseExceptionHandler();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}


using Microsoft.AspNet.OData.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductsCatalogService.API.Model.Data;

namespace ProductsCatalogService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            string conStr = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<ProductsDbContext>(options => 
            {
                options.UseSqlServer(conStr);
            });

            //builder.Services.AddControllers();//by default it is JSON 
            builder.Services.AddControllers().AddXmlDataContractSerializerFormatters().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Injecting the OData
            builder.Services.AddOData();

            var app = builder.Build();

            //Enabling the CORS policy

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();       //This is done if you want uninterrupted calls -> Not restricting any clients

                builder.AllowAnyMethod();
                builder.AllowAnyHeader();

            });

            // To allow only the few clients, we need to create a policy. And testing can only be done if there is a Javascript client



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.EnableDependencyInjection();
                endpoints.Select().OrderBy().Filter().MaxTop(100).SkipToken().Count();
                //endpoints.MapControllers();
            });


            app.MapControllers();

            app.Run();
        }
    }
}

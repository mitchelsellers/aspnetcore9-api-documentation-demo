
using System.Reflection;
using System.Runtime.Intrinsics;
using Microsoft.OpenApi.Models;

namespace DemoApiProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //Swagger UI Implementation
            //If using minimal APIs you must also uncomment this line
            //builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSchemaFilterInstance(new EnumSchemaFilter());
                //Customize overall information
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Demo API",
                    Description = "Demo API for showcasing API documentation",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mitchel Sellers",
                        Url = new Uri("https://www.mitchelsellers.com")
                    }
                });

                //Include our detailed API information from comments
                //NOTE: If you have multiple projects in your solution, you may need to adjust the path to the XML file, or include multiples
                var xmlDocFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //Extra magic to give controller comments too ;)
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlDocFile), true);

            }); //Adds the generation of Swagger UI Documentation

            var app = builder.Build();

            // ONLY show documentation stuffs when in development, alternative you can secure things, but you must do additional work there
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi(); // Served from here: https://localhost:7062/openapi/v1.json

                //Swagger
                app.UseSwagger(); //This registers the service that creates the swagger.JSON file
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = "SwaggerUI"; //Swagger UI served from here: https://localhost:7062/SwaggerUI
                });

                //Redoc
                app.UseReDoc(configuration =>
                {
                    configuration.RoutePrefix = "redoc";
                    configuration.DocumentTitle = "Demo API (ReDoc Version)";
                    configuration.HideDownloadButton(); //Prevent people from downloading the actual spec
                    configuration.DisableSearch(); //We have a really small API!
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

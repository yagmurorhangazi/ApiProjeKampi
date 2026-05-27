using ApiProjeKampi.WebApi.Context;

using ApiProjeKampi.WebApi.Entities;

using ApiProjeKampi.WebApi.ValidationRules;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;



namespace ApiProjeKampi.WebApi

{

    public class Program

    {

        public static void Main(string[] args)

        {

            var builder = WebApplication.CreateBuilder(args);



            // 1. Controller Servisi (API'nin çalýþmasý için þart)

            builder.Services.AddControllers();



            // 2. Veritabaný Context Kaydý (Sadece 1 kere olmasý yeterli)

            builder.Services.AddDbContext<ApiContext>();



            // 3. FluentValidation Kaydý

            // Tek tek AddScoped yazmak yerine, bu satýr projedeki TÜM Validator sýnýflarýný otomatik bulur ve kaydeder.

            builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();



            // 4. AutoMapper Kaydý (Sadece 1 kere olmasý yeterli)

            builder.Services.AddAutoMapper(config =>

            {

                config.AddMaps(typeof(Program).Assembly);

            });




            // Swagger/OpenAPI Ayarlarý

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();



            var app = builder.Build();



            // HTTP Request Pipeline Yapýlandýrmasý

            if (app.Environment.IsDevelopment())

            {

                app.UseSwagger();

                app.UseSwaggerUI();

            }



            app.UseHttpsRedirection();



            app.UseAuthorization();



            app.MapControllers();



            app.Run();

        }

    }

}
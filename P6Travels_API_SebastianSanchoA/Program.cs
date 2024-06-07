using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using P6Travels_API_SebastianSanchoA.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        //agreagamos codigo que permite la inyeccion de la cadena
        //de conexion contenida en appsettings.json

        //1. obtener el valor de la cadena de conexion de appsettings
        var CnnStrBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("CnnStr"));

        //2. Como en la cadena de conexion eliminamos el password, lo vamos
        //a incluir directamente en este codigo fuente
        CnnStrBuilder.Password = "123Queso";

        //3. creamos un string con la info de la cadena de conexion
        string cnnStr = CnnStrBuilder.ConnectionString;

        //4. Vamos a asignar el valor de esta cadena de conexion al
        //DB Context que esta en Models
        builder.Services.AddDbContext<P620242travelsContext>(options => options.UseSqlServer(cnnStr));



        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
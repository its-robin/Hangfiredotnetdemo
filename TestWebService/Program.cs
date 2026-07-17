namespace TestWebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddControllers();
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

                //   app.UseHttpsRedirection();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            
            }catch (Exception ex)
            {
                File.WriteAllText("D:\\startup-error.log", ex.ToString());
                throw; // Re-throw the exception to ensure the application doesn't continue with an invalid state
            }
            
        }

    }
}

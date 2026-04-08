namespace WebApplication_8_April
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}

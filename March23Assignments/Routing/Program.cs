namespace Routing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Privacy}/{id?}");

            //app.MapControllerRoute(
            //    name: "StudentData",
            //    pattern:"studs",
            //    defaults: new {controller="Student",action="GetAllStudents"});

            //app.MapControllerRoute(
            //   name: "Studentsingle",
            //   pattern: "studs/{id}",
            //   defaults: new { controller = "Student", action = "GetStudent" });

            //app.MapControllerRoute(
            //   name: "fewcols",
            //   pattern: "studsfew",
            //   defaults: new { controller = "Student", action = "fewcol" });


            app.Run();
        }
    }
}

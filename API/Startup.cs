using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("hello from use 1st middleware - 1\n");
                await next();
                await context.Response.WriteAsync("hello from use 2nd middleware - 1\n");
            });

            app.UseMiddleware<CustomMiddleware>();

            app.Map("/Junaed", CustomCode); // go to the path that endswith /Junaed, then this middleware will be used.

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("hello from use 1st middleware - 2\n");
                await next();
                await context.Response.WriteAsync("hello from use 2nd middleware - 2\n");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("hello from run\n");
            });
            */
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // middleware
            }
            app.UseRouting(); // middleware

            app.UseEndpoints(endpoints => { // middleware
                /*endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello From new Api");
                });
                endpoints.MapGet("/test", async context =>
                {
                    await context.Response.WriteAsync("Hello From new Api test route");
                });*/

                endpoints.MapControllers();
            });
        }

        private void CustomCode(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("hello from Junaed\n");
            });
        }
    }
}

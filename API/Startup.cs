using API.Repository;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware>();

            services.AddSingleton<IProductRepository, ProductRepository>(); // using singleton for dependency injection so that whenever the route hits
                                                                            // it can't create a new instance and use the existing instance. For this implementation,
                                                                            // id of the product will be 1, 2, 3 in the order they added as their is one instance

            // services.AddScoped<IProductRepository, ProductRepository>(); // -> it'll create isntance every time the route hits. but for the same http request it will share the instance and won't create another instance. 

            // services.AddTransient<IProductRepository, ProductRepository>(); // -> it'll create isntance every time the route hits. And for the same http request it will create another instance. 


            /*
             * using services.AddSingleton, services.AddScoped and services.AddTransient we are registering services
             * if we register same service multiple time, the registration that was done last will work
             * we can  use TryAddSingleton, TryAddScoped and TryAddTransient. It try to register service. If the service is registered earlier than it won't register that service.
             * so if we use try approach and register same service multiple time, only first one will work.
             */
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

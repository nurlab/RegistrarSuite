using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RegistrarSuite.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarSuite.Data.Seed
{
    public static class DbInitializerExtension
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<AppDbContext>();
                DataSeedInitializations.Seed(context);
            }
            catch (Exception ex)
            {

            }

            return app;
        }
    }
}

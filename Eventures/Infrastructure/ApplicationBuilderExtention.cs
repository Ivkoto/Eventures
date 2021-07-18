using System.Linq;
using Eventures.Data;
using Eventures.Data.Enumerations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Eventures.Infrastructure
{
    public static class ApplicationBuilderExtention
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<EventuresDbContext>();

            data.Database.Migrate();

            SeedRoles(data);

            return app;
        }

        private static void SeedRoles(EventuresDbContext data)
        {
            if (data.Roles.Any())
            {
                return;
            }

            data.Roles.AddRange(new []
            {
                new IdentityRole(RolesEnum.Admin.ToString()),
                new IdentityRole(RolesEnum.Regular.ToString()),
                new IdentityRole(RolesEnum.Guest.ToString())
            });

            data.SaveChanges();
        }
    }
}
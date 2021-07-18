using Eventures.Data;
using Eventures.Data.Enumerations;
using Eventures.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Eventures.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<EventuresDbContext>();

            data.Database.Migrate();

            SeedRolesAndCities(data);

            return app;
        }

        private static void SeedRolesAndCities(EventuresDbContext data)
        {
            if (!data.Roles.Any())
            {
                data.Roles.AddRange(new[]
                {
                    new IdentityRole(RolesEnum.Admin.ToString()),
                    new IdentityRole(RolesEnum.Regular.ToString()),
                    new IdentityRole(RolesEnum.Guest.ToString())
                });
            }

            if (!data.Cities.Any())
            {
                data.Cities.AddRange(new[]
                {
                    new City() {Name = "Sofia"},
                    new City() {Name = "Ruse"},
                    new City() {Name = "Varna"},
                    new City() {Name = "Burgas"},
                    new City() {Name = "Plavdiv"}
                });
            }

            data.SaveChanges();
        }
    }
}
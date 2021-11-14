using DocumentTracking.ApplicationCore.Constants;
using DocumentTracking.ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.Data
{
    public class DocumentTrackingContextSeed
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<DocumentTrackingContext>();
            context.Database.EnsureCreated();
            //if (!context.Invoices.Any())
            //{
            //    await context.Invoices.AddAsync(entity: new Invoice() { Name = "Green Thunder" });
            //    await context.Invoices.AddAsync(entity: new Invoice() { Name = "Berry Pomegranate" });
            //    await context.Invoices.AddAsync(entity: new Invoice() { Name = "Betty Crocker" });
            //    await context.Invoices.AddAsync(entity: new Invoice() { Name = "Pizza Crust Mix" });

            //    await context.SaveChangesAsync();
            //}

            //if (!context.InvoiceItems.Any())
            //{
            //    await context.InvoiceItems.AddAsync(entity: new InvoiceItem() { InvoiceId = 1 });
            //    await context.SaveChangesAsync();
            //}

            //if (!context.Metadanes.Any())
            //{
            //    await context.Metadanes.AddAsync(entity: new Metadane() { Name = "" });
            //    await context.SaveChangesAsync();
            //}
        }

        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.ADMINISTRATORS));

            var defaultUser = new ApplicationUser { UserName = "demouser@microsoft.com", Email = "demouser@microsoft.com" };
            await userManager.CreateAsync(defaultUser, AuthorizationConstants.DEFAULT_PASSWORD);

            string adminUserName = "admin@microsoft.com";
            var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };
            await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, AuthorizationConstants.Roles.ADMINISTRATORS);
        }
    }
}

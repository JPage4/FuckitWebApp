using System;
using System.Linq;
using FuckItWebApp.Data;
using FuckItWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FuckItWebApp
{
    public static class DbInitializer
    {
            public static void Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
            {
                var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //seed DB with new fuckits
                if (!context.Fuckit.Any())
                {
                    context.Fuckit.Add(new Fuckit { Name = "Whatevers", Quantity = 0 });
                    context.Fuckit.Add(new Fuckit { Name = "BlahBlah", Quantity = 0 });
                    context.Fuckit.Add(new Fuckit { Name = "Where'd all the fuckits go?", Quantity = 0 });
                    context.Fuckit.Add(new Fuckit { Name = "Where in the world is Carmen McFuckit San Diego?", Quantity = 0 });

                    context.SaveChanges();
                }
            }
        }
    }

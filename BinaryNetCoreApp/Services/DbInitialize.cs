using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinaryNetCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryNetCoreApp.Services
{
    public static class DbInitialize
    {
        public static void Initialize (IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<SimpleModelContext>();
            if (!context.SimpleModels.Any())
            {
                context.SimpleModels.AddRange(
                    new SimpleModel
                    {
                        Id = 1,
                        Name = "SimpleModel",
                        Price= 1,
                        Description = "Description1"
                    },
                    new SimpleModel
                    {
                        Id = 2,
                        Name = "SimpleMode2",
                        Price = 2,
                        Description = "Description2"
                    },
                    new SimpleModel
                    {
                        Id = 3,
                        Name = "SimpleMode3",
                        Price = 3,
                        Description = "Description3"
                    });
            }
        }
    }
}

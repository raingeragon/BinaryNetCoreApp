using BinaryNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryNetCoreApp.Services
{
    public class DbInitializer
    {
        ISimpleModelService service;
        public DbInitializer(ISimpleModelService _service)
        {
            service = _service;
        }
        public void Initialize()
        {
            if (service.GetAllAsync().Result.Count == 0)
            {
                {
                    service.CreateAsync(new SimpleModel
                    {
                        Name = "SimpleModel",
                        Price = 1,
                        Description = "Description1"
                    });
                }
            }
        }
    }
}

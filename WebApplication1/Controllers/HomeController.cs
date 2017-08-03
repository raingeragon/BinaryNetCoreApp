using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BinaryNetCoreApp.Models;
using BinaryNetCoreApp.Services;
using BinaryNetCoreApp.Logger;
using Microsoft.Extensions.Logging;
using System.IO;

namespace BinaryNetCoreApp.Controllers
{

    [Route("api/Home")]
    public class HomeController : Controller
    {
        ISimpleModelService service;
        ILoggerFactory loggerfactory;
        ILogger logger;
        public HomeController(ISimpleModelService service)
        {
            this.service = service;
            loggerfactory = new LoggerFactory().AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logs.txt"));
            logger = loggerfactory.CreateLogger("FileLogger");
        }

        //GET api/Home (GETALL)
        [HttpGet]
        public async Task<List<SimpleModel>> Get()
        {
            logger.LogInformation($"{DateTime.Now.ToString()} Proccessed GET request with SimpleModels db");
            
            return await service.GetAllAsync();
        }

        // GET api/Home/5 (GET by id)
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            SimpleModel simpleModel = await service.GetByIdAsync(id);
            if (simpleModel == null)
            {
                logger.LogInformation($"{DateTime.Now.ToString()} GET request returned BadRequest");
                return BadRequest();
            }
            logger.LogInformation($"{DateTime.Now.ToString()} GET request returned SimpleModel with id={id}");
            return  Ok(simpleModel);
        }

        // POST api/Home (ADD)
        [HttpPost]
        public async Task<IActionResult> Post(string name, int price, string description)
        {
            SimpleModel model = null;
            if (!string.IsNullOrWhiteSpace(name))
                model = new SimpleModel()
                {
                    Name = name,
                    Price = price,
                    Description = description
                };
            
            if (model == null)
            {
                logger.LogInformation($"{DateTime.Now.ToString()} POST request returned BadRequest");
                return BadRequest();
            }

            logger.LogInformation($"{DateTime.Now.ToString()} Proccessed POST request. SimpleModel with name={name}, price={price}, decription = {description} was successfully created");
            await service.CreateAsync(model);
            return Ok(model);
        }

        // DELETE api/Home/5 (DELETEById)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            SimpleModel model = await service.GetByIdAsync(id);
            if (model == null)
            {
                logger.LogInformation($"{DateTime.Now.ToString()} DELETE request returned NotFound");
                return NotFound();
            }
            logger.LogInformation($"{DateTime.Now.ToString()} DELETE request successfully deleted SimpleModel with id={id}");
            await service.DeleteAsync(id);
            return Ok(model);
        }
    }
}
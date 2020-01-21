using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using XirgoPractice.Hub;
using XirgoPractice.Modeling.ModelsDTO;
using XirgoPractice.Services.Interfaces;

namespace XirgoPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;
        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetEntities()
        {
            try
            {
                var items = await _carsService.GetEntities();
                return Ok(items);
            }
            catch (Exception e)
            {
                //Need to change this somehow.
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEntityById(int id)
        {
            try
            {
                var item = await _carsService.GetEntityById(id);
                if (item == null)
                    return NotFound();
                return Ok(item);
            }
            catch (Exception e)
            {
                //Need to change this somehow
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEntity(int id)
        {
            try
            {
                //Need to check if exist for deletion
                await _carsService.DeleteEntity(id);
                return Ok();
            }
            catch (Exception e)
            {
                //Need to change this somehow
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEntity(int id, [FromBody] CarDTO data)
        {
            if (HttpContext.Request.ContentType != "application/json")
                return StatusCode(415);
            try
            {
                var result = await _carsService.UpdateEntity(id, data);


                return Ok(result);
            }
            catch (Exception e)
            {
                //Need to change this somehow
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateEntity([FromBody] CarDTO data)
        {
            if (HttpContext.Request.ContentType != "application/json")
                return StatusCode(415);

            try
            {
                var created = await _carsService.CreateEntity(data);


                return Ok(created);
            }
            catch (Exception e)
            {
                //Need to change this somehow
                Console.WriteLine(e);
                throw;
            }
        }

    }
}

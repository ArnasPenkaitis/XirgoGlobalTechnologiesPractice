using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XirgoPractice.Modeling.ModelsDTO;
using XirgoPractice.Services.Interfaces;

namespace XirgoPractice.Controllers
{
    [ApiController]
    [Route("api/cars/{carid}/[controller]")]
    public class DeviceRecordsController: ControllerBase
    {
        private readonly IDeviceRecordsService _deviceRecordsService;

        public DeviceRecordsController(IDeviceRecordsService deviceRecordsService)
        {
            _deviceRecordsService = deviceRecordsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetEntities(int carid)
        {
            try
            {
                var items = await _deviceRecordsService.GetEntitiesByCar(carid);
                return Ok(items);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEntityById(int carid, int id)
        {
            try
            {
                var item = await _deviceRecordsService.GetEntityByCar(carid, id);
                if (item == null)
                {
                    return NotFound($"Entity with id: {id} not found.");
                }
                return Ok(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateEntity([FromBody] DeviceRecordDTO data, int carid)
        {
            try
            {
                var created = await _deviceRecordsService.CreateEntityByCar(carid, data);
                return Ok(created);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEntity(int carid, int id)
        {
            try
            {
                await _deviceRecordsService.DeleteEntityByCar(carid, id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEntity(int carid, int id, [FromBody] DeviceRecordDTO data)
        {
            try
            {

                var updated = await _deviceRecordsService.UpdateEntityByCar(carid, id, data);
                return Ok(updated);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

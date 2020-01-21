using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using XirgoPractice.DataManagement.BaseRepository.Interfaces;
using XirgoPractice.Hub;
using XirgoPractice.Modeling.Models;
using XirgoPractice.Modeling.ModelsDTO;
using XirgoPractice.Services.Interfaces;

namespace XirgoPractice.Services
{
    public class DeviceRecordsService: IDeviceRecordsService
    {

        private readonly IBaseRepository _deviceRecordsRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<TrackingHub> _hubContext;

        public DeviceRecordsService(IBaseRepository carRepository, IMapper mapper, IHubContext<TrackingHub> hubContext)
        {
            _deviceRecordsRepository = carRepository;
            _mapper = mapper;
            _hubContext = hubContext;
        }


        public async Task<IEnumerable<DeviceRecordDTO>> GetEntitiesByCar(int carid)
        {
            var entityList = await _deviceRecordsRepository.QueryAsync<DeviceRecord>();
            var entitiesSorted = entityList.Where(record => record.CarId == carid);
            var result = _mapper.Map<IEnumerable<DeviceRecordDTO>>(entitiesSorted.OrderByDescending(record => record.CreationDate));
            return result;
        }

        public async Task<DeviceRecordDTO> GetEntityByCar(int carid, int id)
        {
            var entityList = await _deviceRecordsRepository.QueryAsync<DeviceRecord>();

            var entity = entityList.FirstOrDefault(item => item.Id == id && item.CarId == carid);

            var entityDTO = _mapper.Map<DeviceRecordDTO>(entity);

            return entityDTO;
        }

        public async Task<DeviceRecordDTO> CreateEntityByCar(int carid, DeviceRecordDTO data)
        {
            var deviceRecord = _mapper.Map<DeviceRecord>(data);
            deviceRecord.CreationDate = DateTime.Now.ToString();
            deviceRecord.CarId = carid;
            var entity = await _deviceRecordsRepository.CreateAsync(deviceRecord);
            var entityDTO = _mapper.Map<DeviceRecordDTO>(entity);
            await _hubContext.Clients.All.SendAsync(CallTypesEnum.DeviceRecordCreated.ToString(), entityDTO);
            return entityDTO;
        }

        public Task DeleteEntityByCar(int carid, int id)
        {
            //Not implemented because in practice task wasn't required.
            return Task.CompletedTask;
        }

        public Task DeleteEntitiesByCar(int carid)
        {
            //Not implemented because in practice task wasn't required.
            return Task.CompletedTask;
        }

        public async Task<DeviceRecordDTO> UpdateEntityByCar(int carid, int id, DeviceRecordDTO data)
        {
            data.Id = id;
            var deviceRecord = _mapper.Map<DeviceRecord>(data);
            deviceRecord.CreationDate = DateTime.Now.ToString();
            await _deviceRecordsRepository.UpdateAsync(deviceRecord.Id, deviceRecord);
            await _hubContext.Clients.All.SendAsync(CallTypesEnum.DeviceRecordUpdated.ToString(), data);
            return data;
        }
    }
}

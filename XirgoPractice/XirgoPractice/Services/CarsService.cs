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
    public class CarsService : ICarsService
    {
        private readonly IBaseRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<TrackingHub> _hubContext;


        public CarsService(IBaseRepository carRepository, IMapper mapper, IHubContext<TrackingHub> hubContext)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        public async Task<IEnumerable<CarDTO>> GetEntities()
        {
            var entityList = await _carRepository.QueryAsync<Car>();

            var result = _mapper.Map<IEnumerable<CarDTO>>(entityList);

            return result;
        }

        public async Task<CarDTO> GetEntityById(int id)
        {
            var entityList = await _carRepository.QueryAsync<Car>();

            var entity = entityList.FirstOrDefault(item => item.Id == id);

            var entityDTO = _mapper.Map<CarDTO>(entity);

            return entityDTO;
        }

        public async Task<CarDTO> CreateEntity(CarDTO data)
        {
            var car = _mapper.Map<Car>(data);
            var entity = await _carRepository.CreateAsync(car);
            var entityDTO = _mapper.Map<CarDTO>(entity);
            await _hubContext.Clients.All.SendAsync(CallTypesEnum.VehicleCreated.ToString(), entityDTO);
            return entityDTO;
        }

        public async Task<CarDTO> UpdateEntity(int id, CarDTO data)
        {
            data.Id = id;
            var car = _mapper.Map<Car>(data);
            await _carRepository.UpdateAsync(car.Id, car);
            await _hubContext.Clients.All.SendAsync(CallTypesEnum.VehicleUpdated.ToString(), data);
            return data;
        }

        public Task DeleteEntity(int id)
        {
            //Not implemented because in practice task wasn't required.
            return Task.CompletedTask;
        }
    }
}

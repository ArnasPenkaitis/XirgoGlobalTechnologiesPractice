using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XirgoPractice.Modeling.ModelsDTO;

namespace XirgoPractice.Services.Interfaces
{
    public interface ICarsService
    {
        Task<IEnumerable<CarDTO>> GetEntities();
        Task<CarDTO> GetEntityById(int id);
        Task<CarDTO> CreateEntity(CarDTO data);
        Task<CarDTO> UpdateEntity(int id, CarDTO data);
        Task DeleteEntity(int id);
    }
}

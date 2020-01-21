using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XirgoPractice.Modeling.ModelsDTO;

namespace XirgoPractice.Services.Interfaces
{
    public interface IDeviceRecordsService
    {
        Task<IEnumerable<DeviceRecordDTO>> GetEntitiesByCar(int carid);
        Task<DeviceRecordDTO> GetEntityByCar(int carid, int id);
        Task<DeviceRecordDTO> CreateEntityByCar(int carid, DeviceRecordDTO data);
        Task DeleteEntityByCar(int carid, int id);
        Task DeleteEntitiesByCar(int carid);
        Task<DeviceRecordDTO> UpdateEntityByCar(int carid, int id, DeviceRecordDTO data);
    }
}

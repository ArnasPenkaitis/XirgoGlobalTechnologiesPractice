using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XirgoPractice.DataManagement.BaseRepository.Interfaces;

namespace XirgoPractice.Modeling.ModelsDTO
{
    public class DeviceRecordDTO : IBaseEntity
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get; set; }
    }
}

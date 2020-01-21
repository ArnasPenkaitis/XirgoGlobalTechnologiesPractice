using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XirgoPractice.Modeling.Models;
using XirgoPractice.Modeling.ModelsDTO;

namespace XirgoPractice.Modeling
{
    public class MapperConfiguration : AutoMapper.Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<DeviceRecord, DeviceRecordDTO>().ReverseMap();
        }
    }
}

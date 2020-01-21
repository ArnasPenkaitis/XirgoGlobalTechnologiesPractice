using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XirgoPractice.DataManagement.BaseRepository.Interfaces;

namespace XirgoPractice.Modeling.ModelsDTO
{
    public class CarDTO : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

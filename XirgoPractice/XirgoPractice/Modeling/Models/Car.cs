using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XirgoPractice.DataManagement.BaseRepository.Interfaces;

namespace XirgoPractice.Modeling.Models
{
    public class Car : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DeviceRecord> DeviceRecords { get; set; }
    }
}

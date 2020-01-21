using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XirgoPractice.Modeling.Models;

namespace XirgoPractice.DataManagement
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<DeviceRecord> DeviceRecords { get; set; }

    }
}

using DroneServiceDelivery.Helpers;
using DroneServiceDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServiceDelivery.Interface
{
    public interface IGetData
    {
        public Task<List<Drone>> GetDataDrone();
        public Task<List<Location>> GetDataLocation();
    }
}

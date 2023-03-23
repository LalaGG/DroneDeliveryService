using DroneServiceDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServiceDelivery.Interface
{
    public interface IDroneDeliveryService
    {
        public void ExecuteDelivery(List<Drone> drones, List<Location> locations);
    }
}

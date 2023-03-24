using DroneServiceDelivery.Interface;
using DroneServiceDelivery.Models;

namespace DroneServiceDelivery.BusinessLogic
{
    public class DroneDeliveryService : IDroneDeliveryService
    {
        List<Location> totalLocations;
        List<Drone> orderedDrones;
        public void ExecuteDelivery(List<Drone> drones, List<Location> locations)
        {
            // Sort locations by weight in ascending order
            totalLocations = locations.OrderBy(l => l.Weight).ToList();
            // Sort drones by max weight so all the drones will get deliveries
            orderedDrones = drones.OrderByDescending(d => d.MaxWeight).ToList();
            bool isThereMoreLocations = true;
            int tripNumber = 0;

            //if there still locations to assigned continue the trips.
            while (isThereMoreLocations)
            {
                tripNumber++;
                CreateTrips(tripNumber);
                if (totalLocations.Count == 0) isThereMoreLocations = false;
            }
        }

        public void CreateTrips(int tripNumber)
        { 
            // Assign deliveries to drones
            foreach (var location in totalLocations.ToList())
            {
                foreach (Drone drone in orderedDrones.ToList())
                {
                    //if drone still have weight capacity and it to the trip
                    if (drone.CanCarry(location.Weight))
                    {
                        drone.AddDelivery(location.Name, location.Weight);
                        //Remove the locations already added
                        totalLocations.Remove(location);
                        break;
                    }
                }
            }

            // Print deliveries for each drone
            foreach (Drone drone in orderedDrones.ToList())
            {
                //Clean the currentWeight of the drone so it can add new deliveries
                drone.CurrentWeight = 0;
                drone.PrintDeliveries(tripNumber);
                Console.WriteLine();
                //Clean the deliveries already done so they would not be printed in the next Trip
                drone.Deliveries = new List<Location>();
            }
        }
    }
}

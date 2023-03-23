using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServiceDelivery.Models
{
    public class Drone {
        public string Name { get; set; }
        public int MaxWeight { get; set; }
        public int CurrentWeight { get; set; }
        public List<Location> Deliveries { get; set; }

        public Drone(string name, int maxWeight) {
            Name = name;
            MaxWeight = maxWeight;
            CurrentWeight = 0;
            Deliveries = new List<Location>();
        }

        public bool CanCarry(int weight) {
            return CurrentWeight + weight <= MaxWeight;
        }

        public void AddDelivery(string location, int weight) {
            Deliveries.Add(new Location{ Name = location, Weight = weight });
            CurrentWeight += weight;
        }

        public void PrintDeliveries(int tripNumber) {
            if (Deliveries.Count > 0)
            {
                Console.WriteLine($"Trip #{tripNumber}");
                Console.WriteLine("Deliveries for " + Name + ":");
                foreach (var location in Deliveries)
                {
                    Console.WriteLine($"{location.Name} - {location.Weight}");
                }
            }
        }
    }
}

using DroneServiceDelivery.BusinessLogic;
using DroneServiceDelivery.Helpers;
using DroneServiceDelivery.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace DroneServiceDelivery
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ExecuteProgram();
        }
        public static void ExecuteProgram()
        {
            //Create service collection to register DI
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IGetData, GetData>()
            .AddSingleton<IDroneDeliveryService, DroneDeliveryService>()
            .BuildServiceProvider();

            //Get services ill need for th execution of the program
            var serviceGetdata = serviceProvider.GetService<IGetData>();
            var serviceDroneDeliveryService = serviceProvider.GetService<IDroneDeliveryService>();

            //Get Drone Data and Location Data then execute the Delivery Plan
            var drones = serviceGetdata.GetDataDrone().Result;
            var locations = serviceGetdata.GetDataLocation().Result;
            serviceDroneDeliveryService.ExecuteDelivery(drones, locations);
        }
    }
}
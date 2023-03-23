using DroneServiceDelivery.Interface;
using DroneServiceDelivery.Models;

namespace DroneServiceDelivery.Helpers
{
    public class GetData : IGetData
    {
        public async Task<List<Drone>> GetDataDrone()
        {
            // Open the file with StreamReader
            using (StreamReader reader = new StreamReader(@"Data\\Input.txt"))
            {
                // Read first line of the file
                string content = await reader.ReadLineAsync();

                // Clean the data from [ ] and ,
                string[] values = content.Replace("[", "").Replace("]", "").Split(",");

                // Create drone list
                List<Drone> drones = new List<Drone>();

                // Create drone object with for loop
                for (int i = 0; i < values.Length; i += 2)
                {
                    string name = values[i].Trim();
                    int weight = int.Parse(values[i + 1].Trim());
                    drones.Add(new Drone (name, weight));
                }

                return drones;
            }
        }
        public async Task<List<Location>> GetDataLocation()
        {
            // Read all file
            string fileContent = await File.ReadAllTextAsync(@"Data\\Input.txt");

            // Separate each line from the file
            string[] lines = fileContent.Split(Environment.NewLine);

            // Create location list
            List<Location> locations = new List<Location>();

            // Loop from the second line in advanced to get all the locations
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (!string.IsNullOrEmpty(line))
                {
                    string[] values = line.Replace("[", "").Replace("]", "").Split(",");
                    string name = values[0].Trim();
                    int weight = int.Parse(values[1].Trim());
                    locations.Add(new Location { Name = name, Weight = weight });
                }
            }

            return locations;
        }
    }
}

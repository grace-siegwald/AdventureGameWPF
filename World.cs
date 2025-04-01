using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameWPF
{
    public class World
    {
        public Person Player = new Person();
        public List<Location> Locations = new List<Location>();

        public World()
        {
            Locations.Add(new Location()
            {
                Name = "Mountain",
                Description = "Jagged peaks, oh my!",
                LocationImage = "Mountain.bmp"
            });
            Locations.Add(new Location()
            {
                Name = "River",
                Description = "Wow, watch how it flows!",
                LocationImage = "River.bmp"
            });
            Locations.Add(new Location()
            {
                Name = "Hot Springs",
                Description = "Sounds relaxing tbh..."
            });
        }
        
        public string GetLocationList()
        {
            string output = "\nHere are the Locations in the World...\n\n";

            int num = 1;
            foreach (Location location in Locations)
            {
                output += $"{num}) {location.Name}" +
                    $"\n        {location.Description}\n\n";
                num++;
            }
            
            return output;
        }

    }
}

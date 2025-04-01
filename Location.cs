using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameWPF
{
    public class Location
    {
        public string Name;
        public string Description;
        public string LocationImage;

        public string Visit()
        {
            string output = $"You have arrived at {Name}";
            return output;
        }
    }
}

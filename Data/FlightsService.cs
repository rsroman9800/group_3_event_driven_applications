using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Data
{
    // Class made specifically to turn airport codes into objects
    public class FlightsService
    {
        private Dictionary<string, string> airportCodes = new Dictionary<string, string>(); // Airport code objects will be created as dictionary data types
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\airports.csv");

        public FlightsService()
        {
            LoadAirportCodes();
        }

        public void LoadAirportCodes()
        {
            // Separating each airport code into its respective components
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(",");
                string airportCode = parts[0];
                string airportName = parts[1];
                airportCodes[airportCode] = airportName; // Setting airportCode to key and airportName to value for the dictionary item
            }
        }

        public Dictionary<string, string> GetAllAirports()
        {
            return airportCodes;
        }
    }
}

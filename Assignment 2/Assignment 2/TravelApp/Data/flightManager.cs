using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TravelApp.Data
{
    public class flightManager
    {

        public List<Flight> flights = new List<Flight>();


        public List<Flight> FindFlights(string originCode, string destinationCode, DayOfWeek date)
        {
            updateFlights();
            var foundFlights = flights.Where(flight => flight.Origin == originCode && flight.Destination == destinationCode &&  flight.Date == date).ToList();
            return foundFlights;
        }

        private void updateFlights()
        {
            string runningPath = Directory.GetCurrentDirectory();

            // Construct the path to the flights.csv file
            var filePath = Path.Combine(runningPath, "Resources", "res", "flights.csv");

            // Ensure the file path is absolute
            filePath = Path.GetFullPath(filePath);

            string fileName = string.Format(filePath);

            string[] fileLines = File.ReadAllLines(fileName);

            

            foreach (var line in fileLines)
            {
                if (line != "")
                {
                    string[] fileValues = line.Split(",");

                    string flightCode = fileValues[0];
                    string airline = fileValues[1];
                    string originCode = fileValues[2];
                    string destinationCode = fileValues[3];
                    string date = fileValues[4];
                    string time = fileValues[5];
                    int seatsAvailable = int.Parse(fileValues[6]);
                    double cost = double.Parse(fileValues[7]);

                    flights.Add(new Flight(flightCode,airline,originCode,destinationCode,date,time,cost,seatsAvailable));
                }
            }
        }

        
    }
}

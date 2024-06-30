using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Data
{
    public class FlightManager
    {
        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\flights.csv");
        public List<Flight> flights;
        public bool flightsPopulated = false;

        public FlightManager()
        {
            this.flights = new List<Flight>(); // Flights are declared as a list data type using the Flight class
            populateFlights(); // The populate flights method is run
        }

        private void populateFlights()
        {
            if (flightsPopulated) return; // This ensures that the populateFlights() method is only run once

            // Separating each component of the flights.csv file and creating a new flight object out of it
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split(",");
                string flightCode = parts[0];
                string airline = parts[1];
                string originCode = parts[2];
                string destinationCode = parts[3];
                string dayOfWeek = parts[4];
                string time = parts[5];
                int seatsAvailable = int.Parse(parts[6]);
                double cost = double.Parse(parts[7]);

                var flight = new Flight(flightCode, airline, originCode, destinationCode, dayOfWeek, time, cost, seatsAvailable);
                flights.Add(flight);
            }
            flightsPopulated = true; // Turns the flightsPopulated flag from false to true to ensure the method is only run once
        }
        public List<Flight> FindFlights(string originCode, string destinationCode, string dayOfWeek)
        {
            // Matches flights where origin, destination, or day of the week match with the input given by the user. DayOfWeek could be optional for the user, therefore, it can be null/empty and doesn't have to match
            var foundFlights = flights.Where(flight => flight.Origin == originCode && flight.Destination == destinationCode && (string.IsNullOrEmpty(dayOfWeek) || flight.DayOfWeek == dayOfWeek)).ToList();
            return foundFlights;
        }
    }
}

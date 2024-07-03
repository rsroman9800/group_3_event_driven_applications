using Blazorise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Data
{
    public class Flight
    {
        public string FlightCode { get; set; }
        public string Airline { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DayOfWeek Date { get; set; }
        public string Time { get; set; }
        public double Cost { get; set; }
        public int SeatsAvailable { get; set; }

        public Flight()
        {

        }
        public Flight(string flightCode, string airline, string origin, string destination, string date, string time, double cost, int seatsAvailable)
        {
            FlightCode = flightCode;
            Airline = airline;
            Origin = origin;
            Destination = destination;
            Date = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), date);
            Time = time;
            Cost = cost;
            SeatsAvailable = seatsAvailable;
        }

        public override string ToString()
        {
            return $"{FlightCode} - {Airline} from {Origin} to {Destination} on {Date} at {Time}, Cost: {Cost:C}, Seats Available: {SeatsAvailable}";
        }
    }
}
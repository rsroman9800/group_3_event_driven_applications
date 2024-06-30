using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Data
{
    public class Reservation
    {
        public string ReservationCode { get; set; }
        public Flight Flight { get; set; }
        public string TravelerName { get; set; }
        public string Citizenship {  get; set; }
        public bool IsActive { get; set; }

        public Reservation() { }


        public override string ToString()
        {
            return $"{ReservationCode} - {Flight.FlightCode} - {TravelerName} - {Citizenship} - {(IsActive ? "Active" : "Inactive")}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Data
{
    public class ReservationManager
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\reservations.csv");
        private List<Reservation> reservations = new List<Reservation>(); // Creates reservations list data type object
        private static Random random = new Random(); // To be used to generate reservation codes

        public ReservationManager()
        {
            LoadReservations();
        }

        public void LoadReservations()
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                // Separates each component of a reservation into its respective parts and adds the object into the reservations List
                string[] parts = line.Split(",");
                var reservation = new Reservation
                {
                    ReservationCode = parts[0],
                    Flight = new Flight
                    {
                        FlightCode = parts[1],
                        Airline = parts[2],
                        Cost = double.Parse(parts[3]),
                    },
                    TravelerName = parts[4],
                    Citizenship = parts[5],
                    IsActive = bool.Parse(parts[6])
                };

                reservations.Add(reservation);
            }
        }

        public Reservation MakeReservation(Flight flight, string travelerName, string citizenship)
        {
            // Exception messages displayed if flight, name, citizenship is empty/null and/or if the flight does not have any seats available.
            if (flight == null) throw new ArgumentNullException("Flight cannot be null.");

            if (string.IsNullOrEmpty(travelerName)) throw new InvalidNameException("Traveler's name cannot be null or empty.");

            if (string.IsNullOrEmpty(citizenship)) throw new InvalidCitizenshipException("Citizenship cannot be null or empty.");

            if (flight.SeatsAvailable <= 0) throw new NoMoreSeatsException("No seats available.");

            flight.SeatsAvailable--; // Reduces the seat count by 1.

            // Creates a new reservation object using the Reservation class and adds it to the reservations list.
            var reservation = new Reservation
            {
                ReservationCode = GenerateReservationCode(),
                Flight = flight,
                TravelerName = travelerName,
                Citizenship = citizenship,
                IsActive = true,
            };
            reservations.Add(reservation);
            return reservation;
        }

        // Finds reservations based on either reservation code and/or airline, and/or the traveler's name.
        public List<Reservation> FindReservations(string reservationCode, string airline, string travelerName)
        {
            return reservations.Where(r =>
                (string.IsNullOrEmpty(reservationCode) || r.ReservationCode == reservationCode) &&
                (string.IsNullOrEmpty(airline) || r.Flight.Airline == airline) &&
                (string.IsNullOrEmpty(travelerName) || r.TravelerName == travelerName)).ToList();
        }

        // Gets all reservations - to be used if the user does not input a reservation code, airline, or traveler name.
        public List<Reservation> GetAllReservations()
        {
            return reservations;
        }

        // Allows the user to update the reservation's traveler name, citizenship, or if its activity.
        public void UpdateReservation(string reservationCode, string travelerName, string citizenship, bool isActive)
        {
            var reservation = reservations.FirstOrDefault(r => r.ReservationCode == reservationCode); // Finds the first match of the reservation code
            if (reservation != null && travelerName !=null && citizenship!= null)
            {
                reservation.TravelerName = travelerName;
                reservation.Citizenship = citizenship;
                reservation.IsActive = isActive;
            }
            else
            {
                throw new Exception("Reservation must not have any empty fields!");
            }
        }

        private string GenerateReservationCode()
        {
            char letter = (char)random.Next('A', 'Z' + 1); // Generates a random uppercase letter between A to Z
            int numbers = random.Next(1000, 10000); // Generates a random number between 1000 and 9999
            return $"{letter}{numbers}"; // Returns the reservation code
        }

        public void Persist()
        {
            var lines = reservations.Select(r =>
                $"{r.ReservationCode},{r.Flight.FlightCode},{r.Flight.Airline},{r.Flight.Cost},{r.TravelerName},{r.Citizenship},{r.IsActive}")
                .ToArray(); // Transforming each reservation object into a CSV formatted string
            File.WriteAllLines(filePath, lines);
        }
    }
}

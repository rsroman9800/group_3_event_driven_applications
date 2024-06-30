using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Data
{
    public class NoMoreSeatsException : Exception
    {
        public NoMoreSeatsException(string message) : base(message) { }
    }
}

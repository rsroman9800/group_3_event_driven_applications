﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Data
{
    public class InvalidCitizenshipException : Exception
    {
        public InvalidCitizenshipException(string message) : base(message) { }
    }
}

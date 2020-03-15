using AirportInformationBoard.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportInformationBoard.Models
{
    public class Info
    {
        public DateTime DateTime { get; private set; }
        public Cities City { get; private set; }

        public Info(DateTime dateTime, Cities city)
        {
            DateTime = dateTime;
            City = city;
        }
    }
}

using AirportInformationBoard.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace AirportInformationBoard.Utils
{
    public static class Helpers
    {
        public static AircraftNames GetRandomAircraft(Random rand)
        { 
            return (AircraftNames)Enum.GetValues(typeof(AircraftNames)).GetValue(rand.Next(Enum.GetNames(typeof(AircraftNames)).Length));
        }

        public static Cities GetRandomCity(Random rand)
        {
            return (Cities)Enum.GetValues(typeof(Cities)).GetValue(rand.Next(Enum.GetNames(typeof(Cities)).Length));
        }

        public static string GetRandomText(Random rand, int length)
        {
            var text = string.Empty;
            for (int i = 0; i < length; i++)
                text += (char)('a' + rand.Next(0, 26));
            return text;
        }
    }
}

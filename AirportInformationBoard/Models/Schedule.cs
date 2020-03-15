using AirportInformationBoard.Utils;
using System;
using System.Timers;

namespace AirportInformationBoard.Models
{
    public enum Status
    {
        /// <summary>
        /// Ожидает
        /// </summary>
        Waiting,
        /// <summary>
        /// Вылетел
        /// </summary>
        FlewOut,
        /// <summary>
        /// Прилетел
        /// </summary>
        FlewIn,
    }
    public class Schedule
    {
        public AircraftType AircraftType { get; set; }
        public Status CurrentStatus { get; private set; }
        public Info Departure { get; set; }
        public Info Arrival { get; set; }
        public int PassengerCount { get; private set; }

        private const int MinFlightTime = 900000;
        private const int MaxFlightTime = 86400000;

        public Schedule() { }

        public Schedule(DateTime departure)
        {
            Random rand = new Random();
            AircraftType = new AircraftType(Helpers.GetRandomAircraft(rand), Helpers.GetRandomText(rand, rand.Next(3, 10)), rand.Next(1, 500));
            Departure = new Info(departure, Helpers.GetRandomCity(rand));

            Cities ArrivalCity;
            do
            {
                ArrivalCity = Helpers.GetRandomCity(rand);
            }
            while (ArrivalCity == Departure.City);

            Arrival = new Info(departure.AddMilliseconds(MinFlightTime + rand.NextDouble() * rand.Next(MinFlightTime, MaxFlightTime)), ArrivalCity);
        }

        public int Start(int pasCount)
        {
            PassengerCount = pasCount;
            CurrentStatus = Status.FlewOut;
            Console.WriteLine($"Aircraft {AircraftType.Name} flying {Departure.City}({Departure.DateTime}) - {Arrival.City}({Arrival.DateTime}) CAP={PassengerCount}/{AircraftType.Capacity}");
            return pasCount;
        }

        public int Stop()
        {
            CurrentStatus = Status.FlewIn;
            Console.WriteLine($"Aircraft {AircraftType.Name} flying OUT {Departure.City}({Departure.DateTime}) - {Arrival.City}({Arrival.DateTime})");
            return PassengerCount;
        }
    }
}

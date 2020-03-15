using AirportInformationBoard;
using AirportInformationBoard.Models;
using AirportInformationBoard.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlightScheduleCreator
{
    class Program
    {
        static DateTime Current;

        static object sync = new object();
        static void Main(string[] args)
        {
            Current = DateTime.Now;

            List<Schedule> list = new List<Schedule>();
            for (int i = 0; i < 1000; i++)
                list.Add(CreateSchedule());

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Schedules");

            var text = Serializator<List<Schedule>>.SerializeToString(list);
            File.WriteAllText(path, text);

            Console.WriteLine("Saved file");

            text = File.ReadAllTextAsync(path).Result;
            var shedules = Serializator<List<Schedule>>.DeSerializeFromString(text);

            Console.WriteLine("Loaded");
            Console.ReadLine();
        }

        static Schedule CreateSchedule()
        {
            Current = Current.AddMinutes(new Random().Next(100));
            return new Schedule(Current);
        }
    }
}

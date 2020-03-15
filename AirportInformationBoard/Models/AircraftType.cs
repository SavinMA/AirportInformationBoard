using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AirportInformationBoard.Models
{
    public enum AircraftNames
    {
        Boeing,
        Aerobus,
        IL,
        YAK,
        Sukhoi,
        Bombardier,
        Cessna,
        Embraer
    }

    public class AircraftType : INotifyPropertyChanged
    {
        private string name;
        private int capacity;

        public string Name
        { 
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; OnPropertyChanged(); }
        }

        public AircraftType() { }
        public AircraftType(AircraftNames name, string postfix, int capacity)
        {
            Name = $"{name}_{postfix}"; ;
            Capacity = capacity;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

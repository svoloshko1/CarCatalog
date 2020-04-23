using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualTask
{
    class Bus : Transport
    {
        public int PassengerCapacity { get; set; }
        public int SeatsNumber { get; set; }
        public Bus(string brand, string transportModel, double engineCapacity, double price, int passengerCapacity, int seatsNumber) : base(brand, transportModel, engineCapacity, price)
        {
            if (passengerCapacity<=0) {
                throw new ArgumentException("Passenger capasity can not be less or equal zero.", nameof(passengerCapacity));
            }
            PassengerCapacity = passengerCapacity;

            if (seatsNumber <= 0)
            {
                throw new ArgumentException("Passenger capasity can not be less or equal zero.", nameof(seatsNumber));
            }
            SeatsNumber = seatsNumber;
        }
        public override string ToString()
        {
            return base.ToString() + $"{PassengerCapacity}\t{SeatsNumber}";
        }
    }
}

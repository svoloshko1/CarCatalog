using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualTask
{
    class CarCatalog
    {
        private List<Transport> transport;
      

        public CarCatalog()
        {
           transport = new List<Transport>();
        }
        public void AddCar(string brand, string transportModel, double engineCapacity, double price, string transmission)
        {
            transport.Add(new Car(brand, transportModel, engineCapacity, price,transmission));
        }

        public void AddBus(string brand, string transportModel, double engineCapacity, double price, int passengerCapacity, int seatsNumber)
        {
            transport.Add(new Bus(brand, transportModel, engineCapacity, price,passengerCapacity,seatsNumber));
        }

    }
}

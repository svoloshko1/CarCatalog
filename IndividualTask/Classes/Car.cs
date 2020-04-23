using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualTask
{
    public class Car : Transport
    {
        public string Transmission { get; set; }
        public Car(string brand, string transportModel, double engineCapacity, double price, string transmission):base(brand,transportModel,engineCapacity,price) {
            if (transmission.Length<0)
            {
                throw new Exception("Name can not be null or empty.");
            }
            Transmission = transmission;
        }
        public override string ToString()
        {
            return base.ToString() + $"\t{Transmission}";
        }
    }
}

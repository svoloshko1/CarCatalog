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
            Transmission = transmission;
        }
        public override string ToString()
        {
            return base.ToString() + $"{Transmission}";
        }
    }
}

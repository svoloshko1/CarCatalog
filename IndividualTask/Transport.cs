using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualTask
{
    public abstract class Transport
    {
        public Brand Brand{get;set;}
        public string TransportModel { get; set; }
        public double EngineCapacity { get; set; }
        public double Price { get; set; }
        public Transport(string brand,string transportModel,double engineCapacity,double price)
        {
            Brand = new Brand(brand);
            TransportModel = transportModel;
            EngineCapacity = engineCapacity;
            Price = price;
        }
        public override string ToString()
        {
            return $"{Brand}\t{TransportModel}\t{EngineCapacity}\t{Price}\t";
        }

    }
}

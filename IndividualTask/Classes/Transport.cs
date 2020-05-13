using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualTask
{
    public  class Transport: IComparable
    {
        public string Brand{get;set;}
        public string TransportModel { get; set; }
        public double EngineCapacity { get; set; }
        public double Price { get; set; }
       
        public Transport(string brand,string transportModel,double engineCapacity,double price)
        {
            if (brand.Length<0)
            {
                throw new Exception("Brand can not be null or empty.");
            }
            Brand = brand;

            if (transportModel.Length<0)
            {
                throw new Exception( "Transport model can not be null or empty.");
            }
            TransportModel = transportModel;
            if (engineCapacity <= 0)
            {
                throw new ArgumentException("Engine capasity can not be less or equal zero.", nameof(engineCapacity));
            }
            EngineCapacity = engineCapacity;
            if (price <= 0)
            {
                throw new ArgumentException("Price can not be less or equal zero.", nameof(price));
            }
            Price = price;
        }
     
        public override string ToString()
        {
            return $"{ Brand}\t{TransportModel}\t{EngineCapacity}\t{Price}";
        }

        public int CompareTo(object obj)
        {
            return Price.CompareTo(obj);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualTask
{
    public class CarCatalog
    {
        private List<Transport> transport;
        public int Count => transport.Count;
        public CarCatalog()
        {
            transport = new List<Transport>();
        }
        public void AddTransport(Transport edition)
        {

        }

        public void AddCar(string brand, string transportModel, double engineCapacity, double price, string transmission)
        {
            transport.Add(new Car(brand, transportModel, engineCapacity, price, transmission));
        }

        public void AddBus(string brand, string transportModel, double engineCapacity, double price, int passengerCapacity, int seatsNumber)
        {
            transport.Add(new Bus(brand, transportModel, engineCapacity, price, passengerCapacity, seatsNumber));
        }
        public void UpdateEdition(string[] editionData, int index)
        {
            transport[index].Brand = editionData[0];
            transport[index].TransportModel = editionData[1];
            transport[index].EngineCapacity = int.Parse(editionData[2]);
            transport[index].Price = int.Parse(editionData[3]);
            switch (transport[index])
            {
                case Car _:

                    ((Car)transport[index]).Transmission = editionData[5];
                    break;
                case Bus _:
                    ((Bus)transport[index]).PassengerCapacity = int.Parse(editionData[5]);
                    ((Bus)transport[index]).SeatsNumber = int.Parse(editionData[6]);
                    break;
            }
        }
        //public void Loaad(string editionsInfo)
        //{
        //    editionsInfo = editionsInfo.Replace("\r", "");
        //    List<string> editionDatas = new List<string>();
        //    editionDatas.AddRange(editionsInfo.Split('\n'));

        //    foreach (var editionData in editionDatas)
        //    {
        //        List<string> data = new List<string>();
        //        data.AddRange(editionData.Split('\t'));
        //        switch (data[0])
        //        {
        //            case "1":
        //                AddCar(data[1],
        //                    data[2],
        //                    double.Parse(data[3]),
        //                    double.Parse(data[4]),
        //                    (data[5])
        //                   );
        //                break;
        //            case "0":
        //                AddBus(data[1],
        //                    data[2],
        //                    double.Parse(data[3]),
        //                    double.Parse(data[4]),
        //                    int.Parse(data[5]),
        //                    int.Parse(data[6]));
        //                break;
        //        }
        //    }
        //    List<string> vs = transport.Select(edition => edition.ToString()).ToList();
        //}
   
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)transport).GetEnumerator();
        }
        public enum EditionType
        {
            Car = 0,
            Bus = 1
        }
     
    }
}

using System;
using CarsRepository.Interface;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarsRepository.CSV
{

    public class CSVRepository : ICarRepository
    {
        string path;

        public CSVRepository()
        {
            var filename = ConfigurationManager.AppSettings["CSVFilename"];
            path = AppDomain.CurrentDomain.BaseDirectory + filename;
        }
        public IEnumerable<Car> GetCars()
        {

            var cars = new List<Car>();

            if (File.Exists(path))
            {
                var sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var elems = line.Split(',');
                    var carDetail = new Car()
                    {
                        Model = elems[1],
                        Manufacturer = elems[0],
                        Price = elems[2],
                        Wiki = elems[3]
                    };
                    cars.Add(carDetail);
                }
            }
            return cars;
        }
    }
}

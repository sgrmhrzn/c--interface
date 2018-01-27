using System;
using CarsRepository.Interface;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;

namespace CarsRepository.JSON
{

    public class JSONRepository : ICarRepository
    {
        string path;

        public JSONRepository()
        {
            var filename = ConfigurationManager.AppSettings["JSONFilename"];
            path = AppDomain.CurrentDomain.BaseDirectory + filename;
        }
        public IEnumerable<Car> GetCars()
        {
            List<Car> cars = new List<Car>();

            JArray carsJsonArray = JArray.Parse(File.ReadAllText(path));
            foreach(var l in carsJsonArray.Children().ToList())
            {
                Car car = new Car();
                car.Model = (string)l["model"];
                car.Manufacturer = (string)l["manufacturer"];
                car.Price = (string)l["price"];
                car.Wiki = (string)l["wiki"];

                cars.Add(car);
            }

            return cars;
        }
    }
}

using System.Collections.Generic;

namespace CarsRepository.Interface
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
    }
}

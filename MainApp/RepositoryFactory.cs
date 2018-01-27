using CarsRepository.CSV;
using CarsRepository.Interface;
using CarsRepository.JSON;
using System;

namespace AssignmentInterface
{
    public static class RepositoryFactory
    {

        public static ICarRepository GetRepository(string repositoryType)
        {
            ICarRepository repository = null;
            switch (repositoryType)
            {
                case "JSON":
                    repository = new JSONRepository();
                    break;
                case "CSV":
                    repository = new CSVRepository();
                    break;
                default:
                    Console.WriteLine("The Repository you have entered is Invalid! Please enter valid one!");
                    break;
            }
            return repository;
        }
    }
}

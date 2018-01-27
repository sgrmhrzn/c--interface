using System;

namespace AssignmentInterface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            main();
        }
        public static void main()
        {
            Console.Write("Please type 'JSON' to display data from JSON file or 'CSV' to display data from CSV file: ");
            var repositoryType = Console.ReadLine();
            
            var getRepository = RepositoryFactory.GetRepository(repositoryType.ToUpper());
            if (getRepository != null)
            {
                var allCarsList = getRepository.GetCars();
                Console.WriteLine("--------------------------***--------------------------");
                Console.WriteLine("Displayed data from " + repositoryType + " File");
                Console.WriteLine("--------------------------***--------------------------");
                foreach (var carList in allCarsList)
                {
                    Console.WriteLine("--------------------------***--------------------------");
                    Console.WriteLine("Car Model: " + carList.Model);
                    Console.WriteLine("Price: " + carList.Price);
                    Console.WriteLine("Manufacturer: " + carList.Manufacturer);
                    Console.WriteLine("Description: " + carList.Wiki);
                    Console.WriteLine("--------------------------***--------------------------");
                }
            }
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Prisoner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Prisoner> prisoners = new List<Prisoner>();

            prisoners.Add(new Prisoner("Иванов Иван Иванович", true));
            prisoners.Add(new Prisoner("Петров Петр Петрович", false));

            Console.WriteLine("Список заключенных");
            foreach (var prisoner in prisoners)
            {
                Console.WriteLine(prisoner);
            }

            var antiGovernmentPrisoners = prisoners.Where(prisoner => prisoner.IsAntiGovernmentCrime);

            foreach (var prisoner in antiGovernmentPrisoners)
            {
                prisoner.IsReleased = true;
            }

            var releasedPrisoners = prisoners.Where(prisoner => prisoner.IsReleased);

            Console.WriteLine("Освобождены заключенные:");
            foreach (var prisoner in releasedPrisoners)
            {
                Console.WriteLine(prisoner);
            }
        }
    }

    public class Prisoner
    {
        public string FullName { get; set; }
        public bool IsAntiGovernmentCrime { get; set; }
        public bool IsReleased { get; set; }

        public Prisoner(string fullName, bool isAntiGovernmentCrime)
        {
            FullName = fullName;
            IsAntiGovernmentCrime = isAntiGovernmentCrime;
            IsReleased = false;
        }

        public override string ToString()
        {
            string crimeDescription = IsAntiGovernmentCrime ? "совершил антиправительственное преступление" : "не совершил антиправительственное преступление";
            string releaseStatus = IsReleased ? "освобожден" : "в тюрьме";
            return $"ФИО: {FullName}, Заключенный {crimeDescription}, Статус: {releaseStatus}.";
        }
    }
}

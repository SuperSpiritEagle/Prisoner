using System;
using System.Collections.Generic;
using System.Linq;

namespace Prisoner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Prisoner> prisoners = new List<Prisoner>
            {
                new Prisoner("Иванов Иван Иванович", true),
                new Prisoner("Петров Петр Петрович", false)
            };

            Console.WriteLine("Список заключенных:");

            Prisoner.PrintPrisoners(prisoners);

            var antiGovernmentPrisoners = prisoners.Where(prisoner => prisoner.IsAntiGovernmentCrime);

            foreach (var prisoner in antiGovernmentPrisoners)
            {
                prisoner.Release();
            }

            var releasedPrisoners = prisoners.Where(prisoner => prisoner.IsReleased);

            Console.WriteLine("Освобождены заключенные:");

            Prisoner.PrintPrisoners(prisoners);
        }
    }

    public class Prisoner
    {
        public Prisoner(string fullName, bool isAntiGovernmentCrime)
        {
            FullName = fullName;
            IsAntiGovernmentCrime = isAntiGovernmentCrime;
            IsReleased = false;
        }

        public string FullName { get; }
        public bool IsAntiGovernmentCrime { get; }
        public bool IsReleased { get; private set; }

        public void Release()
        {
            IsReleased = true;
        }

        public override string ToString()
        {
            string crimeDescription = IsAntiGovernmentCrime ? "совершил антиправительственное преступление" : "не совершил антиправительственное преступление";
            string releaseStatus = IsReleased ? "освобожден" : "в тюрьме";
            return $"ФИО: {FullName}, Заключенный {crimeDescription}, Статус: {releaseStatus}.";
        }

        static public void PrintPrisoners(IEnumerable<Prisoner> prisoners)
        {
            foreach (var prisoner in prisoners)
            {
                Console.WriteLine(prisoner);
            }
        }
    }
}

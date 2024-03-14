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

            prisoners = prisoners.Where(prisoner => !prisoner.IsAntiGovernmentCrime).ToList();

            Console.WriteLine("Cписок после амнистии:");

            Prisoner.PrintPrisoners(prisoners);
        }
    }

    public class Prisoner
    {
        public Prisoner(string fullName, bool isAntiGovernmentCrime)
        {
            FullName = fullName;
            IsAntiGovernmentCrime = isAntiGovernmentCrime;
        }

        public string FullName { get; }
        public bool IsAntiGovernmentCrime { get; }

        public override string ToString()
        {
            string crimeDescription = IsAntiGovernmentCrime ? "совершил антиправительственное преступление" : "не совершил антиправительственное преступление";
            return $"ФИО: {FullName}, Заключенный {crimeDescription}.";
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

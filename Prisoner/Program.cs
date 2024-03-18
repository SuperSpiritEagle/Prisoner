using System;
using System.Collections.Generic;
using System.Linq;

namespace Prisoner
{
    class Program
    {
        static void Main(string[] args)
        {
            Prison prison = new Prison();

            prison.AddPrisoner(new Prisoner("John Doe", CrimeType.Murder));
            prison.AddPrisoner(new Prisoner("Jane Smith", CrimeType.Theft));
            prison.AddPrisoner(new Prisoner("Michael Johnson", CrimeType.Assault));
            prison.AddPrisoner(new Prisoner("Emily Brown", CrimeType.Fraud));
            prison.AddPrisoner(new Prisoner("David Wilson", CrimeType.AntiGovernment));
           
            Console.WriteLine("Список заключенных:");
            prison.PrintPrisoners();

            prison.ApplyAmnesty();

            Console.WriteLine("Cписок после амнистии:");
            prison.PrintPrisoners();
        }
    }

    public enum CrimeType
    {
        Murder,
        Theft,
        Assault,
        Fraud,
        AntiGovernment
    }

    public class Prisoner
    {
        public Prisoner(string fullName, CrimeType crimeType)
        {
            FullName = fullName;
            CrimeType = crimeType;
        }

        public string FullName { get; }
        public CrimeType CrimeType { get; }

        public override string ToString()
        {
            return $"Name: {FullName}, Crime: {CrimeType}";
        }
    }

    public class Prison
    {
        private List<Prisoner> prisoners;

        public Prison()
        {
            prisoners = new List<Prisoner>();
        }

        public void AddPrisoner(Prisoner prisoner)
        {
            prisoners.Add(prisoner);
        }

        public void ApplyAmnesty()
        {
            prisoners = prisoners.Where(prisoner => prisoner.CrimeType != CrimeType.AntiGovernment).ToList();
        }

        public void PrintPrisoners()
        {
            foreach (var prisoner in prisoners)
            {
                Console.WriteLine(prisoner);
            }
        }
    }
}

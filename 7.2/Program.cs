using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2
{
    struct Athlete
    {
        private string famile;
        private double rez1;
        private double rez2;
        private double rez3;

        public Athlete(string famile, double rez1, double rez2, double rez3)
        {
            this.famile = famile;
            this.rez1 = rez1;
            this.rez2 = rez2;
            this.rez3 = rez3;
        }
        public string GetFamile()
        {
            return famile;
        }

        public double GetMaxResult()
        {
            return Math.Max(rez1, Math.Max(rez2, rez3));
        }
    }

    abstract class Discipline
    {
        protected string disciplineName;
        protected Athlete[] athletes;

        protected Discipline(string disciplineName, Athlete[] athletes)
        {
            this.disciplineName = disciplineName;
            this.athletes = athletes;
        }

        public abstract void SortAndPrintAthletes();
    }

    class LongJump : Discipline
    {
        public LongJump(Athlete[] athletes) : base("Прыжки в длину", athletes) { }

        public override void SortAndPrintAthletes()
        {
            Array.Sort(athletes, (x, y) => y.GetMaxResult().CompareTo(x.GetMaxResult()));

            foreach (var athlete in athletes)
            {
                Console.WriteLine("Discipline: {0}", disciplineName);
                Console.WriteLine("Famile: {0,-10} Best Result: {1,-10}", athlete.GetFamile(), athlete.GetMaxResult());
                Console.WriteLine();
            }
        }
    }

    class HighJump : Discipline
    {
        public HighJump(Athlete[] athletes) : base("Прыжки в высоту", athletes) { }

        public override void SortAndPrintAthletes()
        {
            Array.Sort(athletes, (x, y) => y.GetMaxResult().CompareTo(x.GetMaxResult()));

            foreach (var athlete in athletes)
            {
                Console.WriteLine("Discipline: {0}", disciplineName);
                Console.WriteLine("Famile: {0,-10} Best Result: {1,-10}", athlete.GetFamile(), athlete.GetMaxResult());
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Athlete[] longJumpAthletes = new Athlete[3];
            longJumpAthletes[0] = new Athlete("ivanov", 3, 8, 5);
            longJumpAthletes[1] = new Athlete("sidorov", 6, 4, 7);
            longJumpAthletes[2] = new Athlete("smirnov", 9, 10, 5);

            LongJump longJump = new LongJump(longJumpAthletes);
            longJump.SortAndPrintAthletes();

            Athlete[] highJumpAthletes = new Athlete[3];
            highJumpAthletes[0] = new Athlete("ivanov", 7, 5, 9);
            highJumpAthletes[1] = new Athlete("sidorov", 8, 6, 10);
            highJumpAthletes[2] = new Athlete("petrov", 8, 6, 10);

            HighJump highJump = new HighJump(highJumpAthletes);
            highJump.SortAndPrintAthletes();
        }
    }
}

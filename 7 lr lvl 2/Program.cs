using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_lr_lvl_2
{
    struct Athlete
    {
        public string famile;
        public double rez1;
        public double rez2;
        public double rez3;

        public Athlete(string famile, double rez1, double rez2, double rez3)
        {
            this.famile = famile;
            this.rez1 = rez1;
            this.rez2 = rez2;
            this.rez3 = rez3;
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
            Array.Sort(athletes, (x, y) => Math.Max(y.rez1, Math.Max(y.rez2, y.rez3)).CompareTo(Math.Max(x.rez1, Math.Max(x.rez2, x.rez3))));

            foreach (var athlete in athletes)
            {
                Console.WriteLine("Discipline: {0}", disciplineName);
                Console.WriteLine("Famile: {0,-10} Best Result: {1,-10}", athlete.famile, Math.Max(athlete.rez1, Math.Max(athlete.rez2, athlete.rez3)));
                Console.WriteLine();
            }
        }
    }

    class HighJump : Discipline
    {
        public HighJump(Athlete[] athletes) : base("Прыжки в высоту", athletes) { }

        public override void SortAndPrintAthletes()
        {
            Array.Sort(athletes, (x, y) => Math.Max(y.rez1, Math.Max(y.rez2, y.rez3)).CompareTo(Math.Max(x.rez1, Math.Max(x.rez2, x.rez3))));

            foreach (var athlete in athletes)
            {
                Console.WriteLine("Discipline: {0}", disciplineName);
                Console.WriteLine("Famile: {0,-10} Best Result: {1,-10}", athlete.famile, Math.Max(athlete.rez1, Math.Max(athlete.rez2, athlete.rez3)));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_лр_2_ур_3_н
{
    struct Discipline
    {
        private string disciplineName;
        private string famile;
        private double result;

        public Discipline(string name, string famile, double rez1, double rez2, double rez3)
        {
            disciplineName = name;
            this.famile = famile;
            result = Math.Max(rez1, Math.Max(rez2, rez3));
        }

        public void Print()
        {
            Console.WriteLine("Discipline: {0}", disciplineName);
            Console.WriteLine("Famile: {0,-10} Best Result: {1,-10}", famile, result);
        }

        public double GetMaxResult()
        {
            return result;
        }

        public static void Sort(Discipline[] arr, int n)
        {
            for (int i = 1; i < n; i++)
            {
                Discipline key = arr[i];
                int j = i - 1;
                while (j >= 0 && Compare(arr[j], key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        private static int Compare(Discipline d1, Discipline d2)
        {
            return d1.GetMaxResult().CompareTo(d2.GetMaxResult());
        }
    }

    class LongJump
    {
        private Discipline[] athletes;
        private string _disciplineName;

        public LongJump(Discipline[] athletes, string disciplineName)
        {
            this.athletes = athletes;
            _disciplineName = disciplineName;
        }

        public void SortAndPrintAthletes()
        {
            Discipline.Sort(athletes, athletes.Length);

            foreach (var athlete in athletes)
            {
                athlete.Print();
                Console.WriteLine();
            }
        }
    }

    class HighJump
    {
        private Discipline[] athletes;
        private string _disciplineName;

        public HighJump(Discipline[] athletes, string disciplineName)
        {
            this.athletes = athletes;
            _disciplineName = disciplineName;
        }

        public void SortAndPrintAthletes()
        {
            Discipline.Sort(athletes, athletes.Length);

            foreach (var athlete in athletes)
            {
                athlete.Print();
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Discipline[] longJumpAthletes = new Discipline[3];
            longJumpAthletes[0] = new Discipline("Прыжки в длину", "ivanov", 3, 8, 5);
            longJumpAthletes[1] = new Discipline("Прыжки в длину", "sidorov", 6, 4, 7);
            longJumpAthletes[2] = new Discipline("Прыжки в длину", "smirnov", 9, 10, 5);

            LongJump longJump = new LongJump(longJumpAthletes, "Прыжки в длину");
            longJump.SortAndPrintAthletes();

            Discipline[] highJumpAthletes = new Discipline[3];
            highJumpAthletes[0] = new Discipline("Прыжки в высоту", "ivanov", 7, 5, 9);
            highJumpAthletes[1] = new Discipline("Прыжки в высоту", "sidorov", 8, 6, 10);
            highJumpAthletes[2] = new Discipline("Прыжки в высоту", "sidorov", 8, 6, 10);
        }
    }
}

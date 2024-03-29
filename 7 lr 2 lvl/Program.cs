using _7_lr_2_lvl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_lr_2_lvl
{
    abstract class Discipline
    {
        protected string disciplineName;

        public Discipline(string name)
        {
            disciplineName = name;
        }

        public abstract void Print();
        public static void InsertionSort(Discipline[] arr, int n)
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

        protected abstract double GetMaxResult();
    }
}
class LongJump : Discipline
{
    private string _famile_;
    private double _result;

    public LongJump(string famile, double rez1, double rez2, double rez3) : base("Прыжки в длину")
    {
        _famile_ = famile;
        _result = Math.Max(rez1, Math.Max(rez2, rez3));
    }

    public override void Print()
    {
        Console.WriteLine("Discipline: {0}", disciplineName);
        Console.WriteLine("Famile: {0,-10} Best Result: {1,-10}", _famile_, _result);
    }

    protected override double GetMaxResult()
    {
        return _result;
    }
}

class HighJump : Discipline
{
    private string _famile_;
    private double _result;

    public HighJump(string famile, double rez1, double rez2, double rez3) : base("Прыжки в высоту")
    {
        _famile_ = famile;
        _result = Math.Max(rez1, Math.Max(rez2, rez3));
    }

    public override void Print()
    {
        Console.WriteLine("Discipline: {0}", disciplineName);
        Console.WriteLine("Famile: {0,-10} Best Result: {1,-10}", _famile_, _result);
    }

    protected override double GetMaxResult()
    {
        return _result;
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Discipline[] athletes = new Discipline[3];
        athletes[0] = new LongJump("ivanov", 3, 8, 5);
        athletes[1] = new HighJump("sidorov", 6, 4, 7);
        athletes[2] = new HighJump("smirnov", 9, 10, 5);

        Discipline.InsertionSort(athletes, 3);

        foreach (var athlete in athletes)
        {
            athlete.Print();
            Console.WriteLine();
        }
    }
}


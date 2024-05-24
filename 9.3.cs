using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace _7_лр_3_ур_1н
{
    [Serializable]
    public abstract class Group
    {
        protected string _groupa, _potok, _fam;
        protected int _math, _prog, _phys;
        public Group() { } // Конструктор без параметров
        public Group(string group, string potok, string fam, int math, int prog, int phys)
        {
            _groupa = group;
            _potok = potok;
            _fam = fam;
            _math = math;
            _prog = prog;
            _phys = phys;
        }
        public string fam { get => _fam; }
        public string group { get => _groupa; }
        public string potok { get => _potok; }
        public int math { get => _math; }
        public int prog { get => _prog; }
        public int phys { get => _phys; }
        public virtual void sred_rez(Group grops, ref double sr) { }
        public virtual void Print(Group grops, double sred)
        {
            Console.WriteLine("Familiya:{0,10} Potok:{1, 10} Groupa:{2, 10} sredni_rez:{3, 10}", fam, potok, group, sred);
        }
        public void itog_sred(double[][] a, ref double[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                double sum = 0, n = 5;
                for (int j = 0; j < 5; j++)
                {
                    sum += a[i][j];
                }
                b[i] = sum / n;
            }
        }
    }

    [Serializable]
    public class Group1 : Group
    {
        private int _stat;
        private int _hist;
        public Group1() { } // Конструктор без параметров
        public Group1(string group, string potok, string fam, int math, int prog, int phys, int stat, int hist)
         : base(group, potok, fam, math, prog, phys)
        {
            _stat = stat;
            _hist = hist;
        }
        public override void sred_rez(Group grops1, ref double sr)
        {
            double sum = 0, n = 5;
            sum = grops1.prog + grops1.math + grops1.phys + _stat + _hist;
            sr = sum / n;
        }
    }

    [Serializable]
    public class Group2 : Group
    {
        private int _fiz, _teor;
        public Group2() { } // Конструктор без параметров
        public Group2(string group, string potok, string fam, int math, int prog, int phys, int fiz, int teor) :
        base(group, potok, fam, math, prog, phys)
        {
            _fiz = fiz;
            _teor = teor;
        }
        public override void sred_rez(Group grops1, ref double sr)
        {
            double sum = 0, n = 5;
            sum = grops1.prog + grops1.math + grops1.phys + _fiz + _teor;
            sr = sum / n;
        }
    }

    [Serializable]
    public class Group3 : Group
    {
        private int _geog, _eng;
        public Group3() { } // Конструктор без параметров
        public Group3(string group, string potok, string fam, int math, int prog, int phys, int geog, int eng) :
        base(group, potok, fam, math, prog, phys)
        {
            _geog = geog;
            _eng = eng;
        }
        public override void sred_rez(Group grops, ref double sr)
        {
            double sum = 0, n = 5;
            sum = grops.prog + grops.math + grops.phys + _geog + _eng;
            sr = sum / n;
        }
    }

    [Serializable]
    public class Group4 : Group
    {
        private int _his, _fr;
        public Group4() { } // Конструктор без параметров
        public Group4(string group, string potok, string fam, int math, int prog, int phys, int his, int fr) :
            base(group, potok, fam, math, prog, phys)
        {
            _his = his;
            _fr = fr;
        }
        public override void sred_rez(Group grops, ref double sr)
        {
            double sum = 0, n = 5;
            sum = grops.prog + grops.math + grops.phys + _his + _fr;
            sr = sum / n;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание групп студентов
            Group[] groups = new Group[]
            {
                new Group1("1", "pp", "smirn", 3, 2, 5, 3, 5),
                new Group1("1", "pp", "ivanov", 4, 4, 4, 3, 2),
                new Group2("2", "tk", "novikov", 1, 1, 2, 3, 1),
                new Group2("2", "tk", "zorin", 5, 2, 3, 4, 2),
                new Group3("3", "bp", "smir", 5, 4, 5, 3, 1),
                new Group3("3", "bp", "andr", 5, 2, 2, 4, 2),
                new Group4("4", "ft", "kotov", 3, 3, 2, 5, 3),
                new Group4("4", "ft", "stepanov", 3, 2, 5, 3, 2)
            };

            string binaryFilePath = @"groups.dat";

            // Сериализация данных
            
            BinarySerializeFormat binarySerializer = new BinarySerializeFormat();

            
            binarySerializer.Serialize(groups, binaryFilePath);

            // Десериализация данных
            
            Group[] deserializedBinaryGroups = (Group[])binarySerializer.Deserialize(binaryFilePath, typeof(Group[]));

            

            Console.WriteLine("\nДесериализованные данные из Binary:");
            foreach (var group in deserializedBinaryGroups)
            {
                Console.WriteLine(group.fam);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_лр_3_ур_1н
{
    abstract class Group
    {
        protected string _groupa, _potok, _fam;
        protected int _math, _prog, _phys;
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
    class Group1 : Group
    {
        private int _stat;
        private int _hist;
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
    class Group2 : Group
    {
        private int _fiz, _teor;
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
    class Group3 : Group
    {
        private int _geog, _eng;
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
    class Group4 : Group
    {
        private int _his, _fr;
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
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] grops1 = new Group1[5];
            grops1[0] = new Group1("1", "pp", "smirn", 3, 2, 5, 3, 5);
            grops1[1] = new Group1("1", "pp", "ivanov", 4, 4, 4, 3, 2);
            grops1[2] = new Group1("1", "pp", "smir", 2, 3, 5, 2, 4);
            grops1[3] = new Group1("1", "pp", "sidorov", 4, 3, 3, 5, 2);
            grops1[4] = new Group1("1", "pp", "rom", 5, 5, 3, 2, 1);

            Group[] grops2 = new Group2[5];
            grops2[0] = new Group2("2", "tk", "novikov", 1, 1, 2, 3, 1);
            grops2[1] = new Group2("2", "tk", "zorin", 5, 2, 3, 4, 2);
            grops2[2] = new Group2("2", "tk", "mih", 2, 5, 4, 4, 5);
            grops2[3] = new Group2("2", "tk", "ivanv", 2, 5, 5, 4, 5);
            grops2[4] = new Group2("2", "tk", "popov", 2, 1, 1, 5, 3);

            Group[] grops3 = new Group3[5];
            grops3[0] = new Group3("3", "bp", "smir", 5, 4, 5, 3, 1);
            grops3[1] = new Group3("3", "bp", "andr", 5, 2, 2, 4, 2);
            grops3[2] = new Group3("3", "bp", "lom", 2, 2, 5, 4, 5);
            grops3[3] = new Group3("3", "bp", "pol", 2, 3, 3, 3, 3);
            grops3[4] = new Group3("3", "bp", "serg", 2, 1, 3, 4, 5);

            Group[] grops4 = new Group4[5];
            grops4[0] = new Group4("4", "ft", "kotov", 3, 3, 2, 5, 3);
            grops4[1] = new Group4("4", "ft", "stepanov", 3, 2, 5, 3, 2);
            grops4[2] = new Group4("4", "ft", "vorin", 2, 5, 4, 4, 5);
            grops4[3] = new Group4("4", "ft", "alexeev", 5, 5, 2, 4, 5);
            grops4[4] = new Group4("4", "ft", "hap", 5, 1, 5, 4, 5);

            Group[][] grops = new Group[][]

            { grops1, grops2, grops3, grops4 };
            Group[][] gropsbp = new Group[3][];
            double[] sred_student1 = new double[5];
            double[] sred_student2 = new double[5];
            double[] sred_student3 = new double[5];
            double[][] sred = new double[][]
            { sred_student1, sred_student2, sred_student3 };
            double sr = 0;
            int k = 0;
            for (int i = 0; i < grops.Length; i++)
            {
                string bp = "bp";
                if (grops[i][i].potok.Equals(bp))
                {
                    gropsbp[k] = grops[i];
                    for (int j = 0; j < 5; j++)
                    {
                        gropsbp[k][j].sred_rez(gropsbp[k][j], ref sr);
                        sred[k][j] = sr;
                    }
                    k++;
                }
            }
            double[] sredn = new double[3];
            gropsbp[0][0].itog_sred(sred, ref sredn);
            sort(gropsbp, sredn);

            for (int i = 0; i < gropsbp.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    gropsbp[i][j].Print(gropsbp[i][j], sredn[i]);
                }
            }
        }
        static void sort(Group[][] grops, double[] sr)
        {
            for (int i = 0; i < grops.Length; i++)
            {
                for (int j = 0; j < grops.Length - 1 - i; j++)
                {
                    if (sr[j] < sr[j + 1])
                    {
                        double temp = sr[j];
                        sr[j] = sr[j + 1];
                        sr[j + 1] = temp;

                        Group[] g = grops[j];
                        grops[j] = grops[j + 1];
                        grops[j + 1] = g;
                    }
                }
            }
        }
    }
}

using System;
using Newtonsoft.Json;

// Описание класса Group и его наследников с добавлением сеттеров
[Serializable]
public abstract class Group
{
    protected string _groupa, _potok, _fam;
    protected int _math, _prog, _phys;

    public Group() { }

    public Group(string group, string potok, string fam, int math, int prog, int phys)
    {
        _groupa = group;
        _potok = potok;
        _fam = fam;
        _math = math;
        _prog = prog;
        _phys = phys;
    }

    public string fam { get => _fam; set => _fam = value; }
    public string group { get => _groupa; set => _groupa = value; }
    public string potok { get => _potok; set => _potok = value; }
    public int math { get => _math; set => _math = value; }
    public int prog { get => _prog; set => _prog = value; }
    public int phys { get => _phys; set => _phys = value; }

    public virtual void sred_rez(Group grops, ref double sr) { }

    public virtual void Print(Group grops, double sred)
    {
        Console.WriteLine("Familiya:{0,10} Potok:{1,10} Groupa:{2,10} sredni_rez:{3,10}", fam, potok, group, sred);
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

    public Group1() { }

    public Group1(string group, string potok, string fam, int math, int prog, int phys, int stat, int hist)
        : base(group, potok, fam, math, prog, phys)
    {
        _stat = stat;
        _hist = hist;
    }

    public int stat { get => _stat; set => _stat = value; }
    public int hist { get => _hist; set => _hist = value; }

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

    public Group2() { }

    public Group2(string group, string potok, string fam, int math, int prog, int phys, int fiz, int teor)
        : base(group, potok, fam, math, prog, phys)
    {
        _fiz = fiz;
        _teor = teor;
    }

    public int fiz { get => _fiz; set => _fiz = value; }
    public int teor { get => _teor; set => _teor = value; }

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

    public Group3() { }

    public Group3(string group, string potok, string fam, int math, int prog, int phys, int geog, int eng)
        : base(group, potok, fam, math, prog, phys)
    {
        _geog = geog;
        _eng = eng;
    }

    public int geog { get => _geog; set => _geog = value; }
    public int eng { get => _eng; set => _eng = value; }

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

    public Group4() { }

    public Group4(string group, string potok, string fam, int math, int prog, int phys, int his, int fr)
        : base(group, potok, fam, math, prog, phys)
    {
        _his = his;
        _fr = fr;
    }

    public int his { get => _his; set => _his = value; }
    public int fr { get => _fr; set => _fr = value; }

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

        foreach (var group in groups)
        {
            Console.WriteLine(group.fam);
        }

        try
        {
            string jsonFilePath = "groups.json";
            JsonSerializeFormat jsonSerializer = new JsonSerializeFormat();

            // Десериализация JSON файла в массив объектов Group[]
            Group[] deserializedJsonGroups = (Group[])jsonSerializer.Deserialize(jsonFilePath, typeof(Group[]));

            Console.WriteLine("\nДесериализованные данные из JSON:");
            foreach (var group in deserializedJsonGroups)
            {
                Console.WriteLine($"Family Name: {group.fam}, Group: {group.group}, Stream: {group.potok}, Math: {group.math}, Programming: {group.prog}, Physics: {group.phys}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during deserialization: " + ex.Message);
        }
    }
}

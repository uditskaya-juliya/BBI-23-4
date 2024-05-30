using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProtoBuf;


namespace _7._2
{
    [ProtoContract]
    public struct Athlete
    {
        [ProtoMember(1)]
        public string Famile { get; set; }

        [ProtoMember(2)]
        public double Rez1 { get; set; }

        [ProtoMember(3)]
        public double Rez2 { get; set; }

        [ProtoMember(4)]
        public double Rez3 { get; set; }

        public Athlete(string famile, double rez1, double rez2, double rez3)
        {
            Famile = famile;
            Rez1 = rez1;
            Rez2 = rez2;
            Rez3 = rez3;
        }

        public string GetFamile()
        {
            return Famile;
        }

        public double GetMaxResult()
        {
            return Math.Max(Rez1, Math.Max(Rez2, Rez3));
        }
    }

    abstract class Discipline
    {
        protected string DisciplineName;
        protected Athlete[] Athletes;

        protected Discipline(string disciplineName, Athlete[] athletes)
        {
            DisciplineName = disciplineName;
            Athletes = athletes;
        }

        public abstract void SortAndPrintAthletes();
    }

    class LongJump : Discipline
    {
        public LongJump(Athlete[] athletes) : base("Прыжки в длину", athletes) { }

        public override void SortAndPrintAthletes()
        {
            Array.Sort(Athletes, (x, y) => y.GetMaxResult().CompareTo(x.GetMaxResult()));

            foreach (var athlete in Athletes)
            {
                Console.WriteLine("Discipline: {0}", DisciplineName);
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
            Array.Sort(Athletes, (x, y) => y.GetMaxResult().CompareTo(x.GetMaxResult()));

            foreach (var athlete in Athletes)
            {
                Console.WriteLine("Discipline: {0}", DisciplineName);
                Console.WriteLine("Famile: {0,-10} Best Result: {1,-10}", athlete.GetFamile(), athlete.GetMaxResult());
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Athlete[] longJumpAthletes = new Athlete[]
            {
                new Athlete("ivanov", 3, 8, 5),
                new Athlete("sidorov", 6, 4, 7),
                new Athlete("smirnov", 9, 10, 5)
            };

            LongJump longJump = new LongJump(longJumpAthletes);
            longJump.SortAndPrintAthletes();

            Athlete[] highJumpAthletes = new Athlete[]
            {
                new Athlete("ivanov", 7, 5, 9),
                new Athlete("sidorov", 8, 6, 10),
                new Athlete("petrov", 8, 6, 10)
            };

            HighJump highJump = new HighJump(highJumpAthletes);
            highJump.SortAndPrintAthletes();

            string directoryPath = "SerializationResults";
            Directory.CreateDirectory(directoryPath);

            // JSON serialization
            var jsonSerializer = new JsonSerializeFormat<Athlete[]>();
            jsonSerializer.Serialize(longJumpAthletes, Path.Combine(directoryPath, "longJumpAthletes.json"));
            var deserializedJsonLongJump = jsonSerializer.Deserialize(Path.Combine(directoryPath, "longJumpAthletes.json"));
            Console.WriteLine("JSON Deserialized Long Jump:");
            foreach (var athlete in deserializedJsonLongJump)
            {
                Console.WriteLine($"{athlete.GetFamile()} {athlete.GetMaxResult()}");
            }

            jsonSerializer.Serialize(highJumpAthletes, Path.Combine(directoryPath, "highJumpAthletes.json"));
            var deserializedJsonHighJump = jsonSerializer.Deserialize(Path.Combine(directoryPath, "highJumpAthletes.json"));
            Console.WriteLine("JSON Deserialized High Jump:");
            foreach (var athlete in deserializedJsonHighJump)
            {
                Console.WriteLine($"{athlete.GetFamile()} {athlete.GetMaxResult()}");
            }

        }
    }
}

// 7_lr_1_ur_1/Program.cs
using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;

namespace _7_lr_1_ur_1
{
    [ProtoContract]
    public class Challenge
    {
        [ProtoMember(1)]
        public string _fam_;
        [ProtoMember(2)]
        public string club_;
        [ProtoMember(3)]
        public double results1_;
        [ProtoMember(4)]
        public double results2_;
        [ProtoMember(5)]
        public double sum;
        [ProtoMember(6)]
        public bool disqualified;

        public bool Disqualified => disqualified;
        public string Fam => _fam_;

        public Challenge() { }

        public Challenge(string fam, string club, double results1, double results2)
        {
            _fam_ = fam;
            club_ = club;
            results1_ = results1;
            results2_ = results2;
            sum = (results1_ + results2_);
            disqualified = false;
        }

        public void Print() => Console.WriteLine("familiya: {0,-10} club: {1,-10} rez: {2,-10}", _fam_, club_, sum);
        public void Disqualify() => disqualified = true;

        public static void InsertionSort(Challenge[] arr, int n)
        {
            for (int i = 1; i < n; i++)
            {
                Challenge key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j].sum > key.sum)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var challenges = new List<Challenge>
            {
                new Challenge("ivanov", "medv", 8, 5),
                new Challenge("sidorov", "top", 6, 4),
                new Challenge("smirnov", "py", 9, 10),
                new Challenge("dorov", "top", 16, 4),
                new Challenge("mirnov", "py", 19, 10)
            };

            Challenge.InsertionSort(challenges.ToArray(), challenges.Count);

            foreach (var challenge in challenges)
            {
                if (challenge.Disqualified)
                    continue;

                challenge.Print();

                if (challenge == challenges[0])
                {
                    challenge.Disqualify();
                    Console.WriteLine("Disqualified: {0}", challenge.Fam);
                }
            }

            string directoryPath = "SerializationResults";
            Directory.CreateDirectory(directoryPath);

            // JSON serialization
            var jsonSerializer = new JsonSerializer<List<Challenge>>();
            jsonSerializer.Serialize(challenges, Path.Combine(directoryPath, "challenges.json"));
            var deserializedJson = jsonSerializer.Deserialize(Path.Combine(directoryPath, "challenges.json"));
            Console.WriteLine("JSON Deserialized:");
            deserializedJson.ForEach(challenge => challenge.Print());

            // XML serialization
            var xmlSerializer = new XmlSerializer<List<Challenge>>();
            xmlSerializer.Serialize(challenges, Path.Combine(directoryPath, "challenges.xml"));
            var deserializedXml = xmlSerializer.Deserialize(Path.Combine(directoryPath, "challenges.xml"));
            Console.WriteLine("XML Deserialized:");
            deserializedXml.ForEach(challenge => challenge.Print());

            // Binary serialization
            var binarySerializer = new BinarySerializer<List<Challenge>>();
            binarySerializer.Serialize(challenges, Path.Combine(directoryPath, "challenges.bin"));
            var deserializedBinary = binarySerializer.Deserialize(Path.Combine(directoryPath, "challenges.bin"));
            Console.WriteLine("Binary Deserialized:");
            deserializedBinary.ForEach(challenge => challenge.Print());
        }
    }
}

using System;
using System.Collections.Generic;
using Task2;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new List<int>();
            temp.Add(5);
            temp.Add(2);
            temp.Add(34);

            // var testHuman = new List<Human>();
            var human = new List<Human>();
            human.Add(new Human("Pavel", "Belarus", "Gomel"));
            human.Add(new Human("Maxim", "Belarus", "Minsk"));
            human.Add(new Human("Misha", "Russia", "Moscow"));
            human.Add(new Human("Rita", "Belarus", "Gomel"));
            human.Add(new Human("Kolya", "Belarus", "Grodno"));

            var serialization = new SerializationCollection<Human>();

            // serialization.SaveToBinaryFile(@"..\..\..\Test4.bin", human);
            // var testHuman = serialization.GetFromBinaryFile(@"..\..\..\Test4.bin");

            serialization.SaveToJsonFile(@"..\..\..\Test4.json", human);
            var testHuman = serialization.GetCollectionFromJsonFile(@"..\..\..\Test4.json");

            // serialization.SaveToXmlFile(@"..\..\..\Test4.xml", human);
            // var testHuman = serialization.GetFromXmlFile(@"..\..\..\Test4.xml");
            // Console.WriteLine(testHuman);
            
            foreach (var item in testHuman)
            {
                Console.WriteLine(item);
            }
        }
    }
}

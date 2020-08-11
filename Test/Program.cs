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


            var human = new List<Human>();
            human.Add(new Human("Pavel", "Belarus", "Gomel"));
            human.Add(new Human("Maxim", "Belarus", "Minsk"));
            human.Add(new Human("Misha", "Russia", "Moscow"));
            human.Add(new Human("Rita", "Belarus", "Gomel"));
            human.Add(new Human("Kolya", "Belarus", "Grodno"));

            var serialization = new SerializationCollection<Human>(human);

            // serialization.SaveToBinaryFile(@"..\..\..\Test4.bin");
            // serialization.GetFromBinaryFile(@"..\..\..\Test4.bin");

            // serialization.SaveToJsonFile(@"..\..\..\Test4.json");
            // serialization.GetFromJsonFile(@"..\..\..\Test4.json");

            // serialization.SaveToXmlFile(@"..\..\..\Test4.xml");
            serialization.GetFromXmlFile(@"..\..\..\Test4.xml");

            foreach (var item in serialization)
            {
                Console.WriteLine(item);
            }
        }
    }
}

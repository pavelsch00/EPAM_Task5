using System;
using System.Collections.Generic;
using Task2;
using Task2.Humans;

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
            Type type = typeof(Human);
            // var testHuman = new List<Human>();
            var human = new List<Human>();
            var humanTesst = new Human("Pavel", "Belarus", "Gomel");
            human.Add(new Human("Pavel", "Belarus", "Gomel"));
            human.Add(new Human("Maxim", "Belarus", "Minsk"));
            human.Add(new Human("Misha", "Russia", "Moscow"));
            human.Add(new Human("Rita", "Belarus", "Gomel"));
            human.Add(new Human("Kolya", "Belarus", "Grodno"));
            var serialization = new SerializationCollection<Human>();
            /*Console.WriteLine(
                Attribute.GetCustomAttributes(typeof(Human))
                .Where(item => item is VersionAttribute)
                .Select(item => item as VersionAttribute)
                .Select(item =>item.VersionClass).FirstOrDefault()
                );*/

                serialization.SaveToBinaryFile(@"..\..\..\Test4.bin", human);
               var testHuman = serialization.GetCollectionFromBinaryFile(@"..\..\..\Test4.bin");

            // serialization.SaveToJsonFile(@"..\..\..\Test4.json", human);
            // var testHuman = serialization.GetCollectionFromJsonFile(@"..\..\..\Test4.json");

            // serialization.SaveToXmlFile(@"..\..\..\Test4.xml", human);
            // var testHuman = serialization.GetCollectionFromXmlFile(@"..\..\..\Test4.xml");
            // Console.WriteLine(testHuman);
            //Attribute.GetCustomAttributes(typeof(Human)).Select(item => item as VersionAttribute).Select(item => item.VersionClass);
            /*foreach (var item in Attribute.GetCustomAttributes(typeof(Human)))
            {
                if(item is VersionAttribute)
                {
                    var test = (VersionAttribute)item;
                    Console.WriteLine($"{item}, {test.VersionClass}");
                }
            }*/

            foreach (var item in testHuman)
            {
                Console.WriteLine(item);
            }
        }
    }
}

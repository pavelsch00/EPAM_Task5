using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task2
{
    [Serializable]
    public class Human : ISerializable
    {
        public Human()
        {
        }

        public Human(string name, string country, string city)
        {
            Name = name;
            City = city;
            Country = country;
        }

        public Human(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            City = (string)info.GetValue("City", typeof(string));
            Country = (string)info.GetValue("Country", typeof(string));
        }

        public string Name { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("City", City);
            info.AddValue("Country", Country);
        }

        public override string ToString() => $"Name: {Name}, City: {City}, Country: {Country}";
    }
}

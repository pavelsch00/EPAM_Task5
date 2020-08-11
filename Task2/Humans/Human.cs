using System;
using System.Runtime.Serialization;
using Task2.SerializationCollections.Attributes;

namespace Task2.Humans
{
    [Serializable]
    [Version(2, 1, 0, 1)]
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

        /// <summary>
        /// Method equals two objects.
        /// </summary>
        /// <param name="obj">Equals object.</param>
        /// <returns>Returns the result of the comparison</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;

            Human human = (Human)obj;

            return Name == human.Name &&
                   City == human.City &&
                   Country == human.Country;
        }

        /// <summary>
        /// The method gets the hash code of the object.
        /// </summary>
        /// <returns>Returns the hash code of the object.</returns>
        public override int GetHashCode() => HashCode.Combine(Name, City, Country);

        /// <summary>
        /// The method returns information about the object in string form.
        /// </summary>
        /// <returns>Information about the object.</returns>
        public override string ToString() => $"Name: {Name}, City: {City}, Country: {Country}";
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task2.Interfaces
{
    interface ISerializationCollection<T> where T : ISerializable
    {
        public void SaveToXmlFile();

        public void GetFromXmlFile();

        public void SaveToJsonile();

        public void GetFromJsonFile();

        public void SaveToBinaryFilelFile();

        public void GetFromBinaryFileFile();
    }
}

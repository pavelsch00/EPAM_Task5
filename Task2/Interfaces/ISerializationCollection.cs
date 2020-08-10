using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task2.Interfaces
{
    interface ISerializationCollection
    {
        public void SaveToXmlFile(string path);

        public void GetFromXmlFile(string path);

        public void SaveToJsonile(string path);

        public void GetFromJsonFile(string path);

        public void SaveToBinaryFilelFile(string path);

        public void GetFromBinaryFileFile(string path);
    }
}

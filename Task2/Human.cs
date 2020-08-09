using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Human
    {
        public Human()
        {
            Version = new Version(1, 0, 0, 0);
        }

        public Version Version { get; set; }
    }
}

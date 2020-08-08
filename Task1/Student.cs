using System;

namespace Task1
{
    public class Student : IComparable
    {
        private int assessment;

        public Student()
        {
        }

        public Student(string name, string testName, string testDate, int assessment)
        {
            Name = name;
            TestName = testName;
            TestDate = testDate;
            Assessment = assessment;
        }

        public string Name { get; set; }

        public string TestName { get; set; }

        public string TestDate { get; set; }

        public int Assessment
        {
            get => assessment;
            set
            {
                if (value >= 0 && value <= 10)
                    assessment = value;
                else
                    throw new ArgumentException("Invalid assessment");
            }
        }

        public int CompareTo(object obj)
        {
           Student student = (Student)obj;
           return Assessment.CompareTo(student.Assessment);
        }

        public override string ToString() => $"Name: {Name}, Test Name: {TestName}, TestDate: {TestDate}, Assessment: {Assessment}\n";
    }
}

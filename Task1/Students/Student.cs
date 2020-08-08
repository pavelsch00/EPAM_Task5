using System;
using Task1.Students.Interfaces;

namespace Task1.Students
{
    public class Student : IStudent, IComparable
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
                    throw new ArgumentException("Invalid assessment.");
            }
        }

        public int CompareTo(object obj)
        {
           Student student = (Student)obj;
           return Assessment.CompareTo(student.Assessment);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;

            Student student = (Student)obj;

            return Name == student.Name &&
                   TestName == student.TestName &&
                   TestDate == student.TestDate &&
                   Assessment == student.Assessment;
        }

        public override int GetHashCode() => HashCode.Combine(Name, TestName, TestDate, Assessment);

        public override string ToString() => $"Name: {Name}, Test Name: {TestName}, TestDate: {TestDate}, Assessment: {Assessment}\n";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class Student
    {

        public string FullName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Phone { get; private set; }

        public Student(string fullName, DateTime birthday, string phone)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException($"Invalid argument {nameof(fullName)}");
            }
            if (string.IsNullOrEmpty(phone))
            {
                throw new ArgumentException($"Invalid argument {nameof(phone)}");
            }
            if(DateTime.Now < birthday)
            {
                throw new ArgumentOutOfRangeException("birthday", "Is student from future?");
            }
            FullName = fullName;
            Birthday = birthday;
            Phone = phone;
        }
        public override string ToString()
        {
            return $"FullName:{FullName}\nBirthday:{Birthday:d}\nPhone:{Phone}\n";
        }

    }
}

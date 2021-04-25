using System;
using System.Collections.Generic;
using System.Text;

namespace Workers
{
    class Worker
    {
        public Worker(string FirstName, string LastName, string Position, uint Salary, string Department)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.position = Position;
            this.department = Department;
            this.salary = Salary;
        }


        public string Print()
        {
            return $"{this.firstName,15} {this.lastName,15} {this.department,15} {this.position,15} {this.salary,10}";
        }


        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }

        public string LastName { get { return this.lastName; } set { this.lastName = value; } }

        public string Position { get { return this.position; } set { this.position = value; } }

        public string Department { get { return this.department; } set { this.department = value; } }

        public uint Salary { get { return this.salary; } set { this.salary = value; } }

        public double HourRate
        {
            get
            {
                byte workingDays = 25;
                byte workingHours = 8; 
                return ((double)Salary) / workingDays / workingHours;
            }
        }


   
        private string firstName;

        private string lastName;

        private string position;

        private string department;

        private uint salary;
    }
}

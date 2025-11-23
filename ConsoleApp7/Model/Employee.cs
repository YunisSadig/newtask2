using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMadeExceptions;
using People;
using Iinterface;
using WorkerPosition;


namespace Employees
{
   
    
    class Employee:Person,IPrintable
    {
        private decimal _salary;

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value <= 0)
                {
                    throw new InValidSalaryException();
                }
                else
                {
                    _salary = value;
                }
            }
        }
        private string _department;

        public string Department
        {
            get { return _department; }
            set
            {
                if (value == null)
                {
                    throw new NameEmptyException();
                }


                if (value.Length == 5 && value.Length == 6)
                {
                    throw new NameLengthException();
                }
            }
           
        }
        public Position? Position { get; set; }
        public Employee(int id,string name,DateTime hiretime,decimal salary,string department,Position position) : base(id, name, hiretime)
        {
            this.Salary = salary;
            this.Department = department;
            this.Position = position;
        }
        public override void NameInfo()
        {
            Console.WriteLine($"Id:{ID} && Name:{Name} && hiretime={HireTime}");
        }
        public void ShowInfo()
        {
            if (Position == null)
                Console.WriteLine("Position: Not assigned");

            Console.WriteLine($" Salary:{Salary} && Department:{Department} && Position:{Position}");
        }

    }
    
}

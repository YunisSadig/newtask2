using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMadeExceptions;

namespace People
{
    abstract class Person
    {
        public int ID { get; set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NameEmptyException();
                }
                if(value.Length<=25 && value.Length >= 3)
                {
                    throw new NameLengthException();
                }
                else
                {
                    _name = value;
                }
            }
        }

        private DateTime _hiretime;
        public DateTime HireTime 
        {
            get { return _hiretime;}
            set
            {
                if (value == default(DateTime))
                {
                    throw new Exception("Hire datetime cannot be null (N/A)");
                }
                else
                {
                    _hiretime = value;
                }
            }
        }
        public abstract void NameInfo();

        public Person(int id,string name,DateTime hiretime)
        {
            this.ID = id;
            this.Name = name;
            this.HireTime = hiretime;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMadeExceptions
{
    public class DuplicateEmployeeException : Exception
    {
        public DuplicateEmployeeException():base("Employee Already Exsists",new Exception("Probably you have already added it "))
        {

        }
        public DuplicateEmployeeException(string innermessage) : base("Probably you have already added it",new Exception(innermessage))
        {

        }
        public DuplicateEmployeeException(string message, Exception inner): base(message, inner)
        {

        }
    }
    public class EmployeeNotFound : Exception
    {
        public EmployeeNotFound():base("Employee was not found", new Exception("You have entered wrong employee data "))
        {

        }
        public EmployeeNotFound(string innermessage):base("You have entered wrong employee data", new Exception(innermessage))
        {

        }
        public EmployeeNotFound(string message,Exception inner) : base(message, inner)
        {

        }
    }
    public class NameEmptyException : Exception
    {
        public NameEmptyException():base("Name field is empty",new Exception("You have not entered the name"))
        {

        }
        public NameEmptyException(string innermessage):base("You have not entered the name",new Exception(innermessage))
        {

        }
        public NameEmptyException(string message,Exception inner) : base(message, inner)
        {

        }
    }
    public class NameLengthException : Exception 
    {
        public NameLengthException():base("The name is length is more or less than ",new Exception("You have entered wrong number of symbols")) 
        {

        }
        public NameLengthException(string innermessage):base("You have entered wrong number of symbols",new Exception(innermessage))
        {

        }
        public NameLengthException(string message,Exception inner) : base(message, inner)
        {

        }
    }
    public class InValidSalaryException : Exception 
    {
        public InValidSalaryException():base("You have entered wrong salary expression",new Exception("It maybe more or less than salary"))
        {

        }
        public InValidSalaryException(string innermessage):base("It maybe more or less than than salary",new Exception(innermessage))
        {

        }
        public InValidSalaryException(string message, Exception inner) : base(message, inner)
        {

        }
    }
    public class InValidWorkInfoException : Exception
    {
        public InValidWorkInfoException():base("Invalid WorkInfo ",new Exception("Workinfo probably does not fit to actaul work info"))
        {

        }
        public InValidWorkInfoException(string innermessage):base("Workinfo probably does not fit to actaul work info",new Exception(innermessage))
        {

        }
        public InValidWorkInfoException(string message,Exception inner) : base(message, inner)
        {

        }
    }
    public class FileLoadException : Exception
    {
        public FileLoadException() :base("File cannot be read",new Exception("It is probably empty"))
        {

        }
        public FileLoadException(string innermessage):base("It is probably empty",new Exception(innermessage))
        {

        }
        public FileLoadException(string message, Exception inner) : base(message, inner)
        {

        }
    }
    
}

using Contacts;
using CustomMadeExceptions;
using Employees;
using Iinterface;
using People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using WorkerPosition;
using System.IO;


namespace Service
{
    class EmployeeService
    {
        List<Employee> employees = new List<Employee>();

        public void AddEmployee(int id, string name, DateTime hiretime, decimal salary, string department, Position position)
        {
            foreach(var employee in employees)
            {
                if (employee.ID == 0 || employee.Name == null)
                {
                    throw new EmployeeNotFound();
                }

                if (employee.ID == id)
                {
                    throw new DuplicateEmployeeException();
                }
               
            }
            Employee newemployee = new Employee( id,  name,  hiretime,salary,  department,  position);
            employees.Add(newemployee);
        }
        public List<Employee> RemoveEmployee(int id, string name)
        {
            foreach(var employee in employees)
            {
                if (employee.ID == 0 || employee.Name == null)
                {
                    throw new EmployeeNotFound();
                } 
            }
            for(int i = 0; i < employees.Count; i++)
            {
                if (employees[i].ID==id || employees[i].Name == name)
                {
                    employees.RemoveAt(i);
                }
            }
            return employees;
        } 
        public List<Employee> SearchEmployee(int id, string name)
        {
            List<Employee> search = new List<Employee>();
            foreach (var employee in employees)
            {
                if (employee.ID == 0 || employee.Name == null)
                {
                    throw new EmployeeNotFound();
                }
                for(int i = 0; i < employees.Count; i++)
                {
                    if (employees[i].ID == id || employees[i].Name == name)
                    {
                        search.Add(employee);
                    }
                }
            }
            return search;
        }
        public List<Employee> UpdateEmployee(int id, string newname)
        {
            List<Employee> updateddata = new List<Employee>();
            foreach (var employee in employees)
            {
                if (employee.ID == 0 || employee.Name == null)
                {
                    throw new EmployeeNotFound();
                }
            }
            for(int i = 0; i < employees.Count; i++)
            {
                if (employees[i].ID == id)
                {
                    employees[i].Name = newname;
                    updateddata.Add(employees[i]);
                }
            }
            return updateddata;
        }
        public void ListEmployee()
        {
            foreach(var employee in employees)
            {
                Console.WriteLine($"{employee.ID},{employee.Name},{employee.HireTime},{employee.Salary},{employee.Salary}");
            }
        }
        public List<Employee> SortEmployee(string field)
        {
           for(int i = 0; i < employees.Count-1; i++)
            {
                for(int j = 0; j < employees.Count - i-1; j++)
                {
                    bool swap = false;

                    if (field.ToLower()=="id" && employees[j].ID > employees[j + 1].ID)
                    {
                         swap = true;
                    }
                    else if(field.ToLower()=="name" && string.Compare(employees[j].Name, employees[j + 1].Name) > 0)
                    {
                        swap = true;
                    }
                    else if(field.ToLower()=="hiretime" && employees[j].HireTime > employees[j + 1].HireTime)
                    {
                        swap = true;
                    }
                    else if(field.ToLower()=="salary" && employees[j].Salary > employees[j + 1].Salary)
                    {
                        swap = true;
                    }

                    if (swap)
                    {
                        Employee temp = employees[j];
                        employees[j] = employees[j+1];
                        employees[j] = employees[j + 1];
                    }
                }
           }
            return employees;
        }
        public List<Employee> FilterEmployees(string nameinput)
        {
            List<Employee> filterapply = new List<Employee>();
          
           foreach(var employee in employees)
           {
                if (nameinput == null)
                {
                    return null;
                }
                if (employee.Name == nameinput)
                {
                    filterapply.Add(employee);
                }
           }
            return filterapply;
        }
        public decimal FilterBySalaryEmployees()
        {
            List<decimal> filterapply = new List<decimal>();

            foreach (var employee in employees)
            {
                if (employee.Salary == null)
                {
                    return 0;
                }
                filterapply.Add(employee.Salary);

            }
            filterapply.Sort();
            decimal min = filterapply[0];
            decimal max = filterapply[filterapply.Count - 1];
            return min;
            return max;

        }
        public void SaveToFile()
        {
            try
            {
                string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch
            {
                throw new FileLoadException();
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    employees = new List<Employee>();
                    return;
                }
                string json = File.ReadAllText(filePath);
                employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            }
            catch
            {
                throw new FileLoadException();
            }
        }
    }
}

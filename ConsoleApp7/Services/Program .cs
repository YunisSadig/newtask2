using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMadeExceptions;
using People;
using Iinterface;
using WorkerPosition;
using Service;
using Employees;
using System.ComponentModel;

namespace Core
{
    class Program
    {
        static void Main()
        {
            EmployeeService employeeService = new EmployeeService();

            while (true)
            {
                try
                {
                    Console.WriteLine("\n=== EMPLOYEE MENU ===");
                    Console.WriteLine("1. Add Employee");
                    Console.WriteLine("2. Remove Employee");
                    Console.WriteLine("3. Search Employee");
                    Console.WriteLine("4. Update Employee");
                    Console.WriteLine("5. List Employees");
                    Console.WriteLine("6. Sort  Employees");
                    Console.WriteLine("7. Filter salarie's Employees");
                    Console.WriteLine("8. Sort names' Employees");
                    Console.WriteLine("9 to save file");
                    Console.WriteLine("0. Exit");

                    Console.Write("Choose: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Add the data");

                            Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
                            Console.Write("Name: "); string name = Console.ReadLine();
                            Console.Write("Hire date (yyyy-mm-dd): "); DateTime hire = DateTime.Parse(Console.ReadLine());
                            Console.Write("Salary: "); decimal salary = decimal.Parse(Console.ReadLine());
                            Console.Write("Department: "); string dept = Console.ReadLine();
                            Console.Write("Position (0-Junior,1-Middle,2-Senior,3-Manager): ");
                            Position pos = (Position)int.Parse(Console.ReadLine());

                            employeeService.AddEmployee(id, name, hire, salary, dept, pos);
                            Console.WriteLine("Employee added.");
                            break;

                        case 2:
                            Console.WriteLine("Add Id and Number");
                            id = int.Parse(Console.ReadLine());
                            name = Console.ReadLine();
                            employeeService.RemoveEmployee(id, name);
                            Console.WriteLine("Employee removed");
                            break;
                        case 3:
                            Console.WriteLine("Add Id and Number");
                            id = int.Parse(Console.ReadLine());
                            name = Console.ReadLine();
                            employeeService.SearchEmployee(id, name);
                            Console.WriteLine("Employee found");
                            break;
                        case 4:
                            Console.WriteLine("Add id and newname");
                            id = id = int.Parse(Console.ReadLine());
                            string newname = Console.ReadLine();
                            employeeService.UpdateEmployee(id, newname);
                            Console.WriteLine("Employee updated");
                            break;
                        case 5:
                            Console.WriteLine("EmployyeList");
                            employeeService.ListEmployee();
                            break;
                        case 6:
                            Console.WriteLine("Add field using which you wanna use");
                            string field = Console.ReadLine();
                            employeeService.SortEmployee(field);
                            Console.WriteLine("Sorted list");
                            break;
                        case 7:
                            Console.WriteLine("Enter name to choose employee ");
                            string nameinput = Console.ReadLine();
                            employeeService.FilterEmployees(nameinput);
                            Console.WriteLine("Found name");
                            break;
                        case 8:
                            Console.WriteLine("Find min and max salary");
                            employeeService.FilterBySalaryEmployees();
                            Console.WriteLine("Max and Min");
                            break;
                        case 9: 
                            {
                                employeeService.SaveToFile();
                                Console.WriteLine("Data saved. Exiting...");
                                break;
                            }
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
                catch (DuplicateEmployeeException e)
                {
                    Console.WriteLine("Error" + e.Message);
                    if (e.InnerException != null)
                    {
                        Console.WriteLine("Error" + e.InnerException.Message);
                    }
                }
                catch (NameEmptyException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    if (ex.InnerException != null)
                        Console.WriteLine("Details: " + ex.InnerException.Message);
                }
                catch (NameLengthException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    if (ex.InnerException != null)
                        Console.WriteLine("Details: " + ex.InnerException.Message);
                }
                catch (InValidSalaryException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    if (ex.InnerException != null)
                        Console.WriteLine("Details: " + ex.InnerException.Message);
                }
                catch (InValidWorkInfoException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    if (ex.InnerException != null)
                        Console.WriteLine("Details: " + ex.InnerException.Message);
                }
                catch (EmployeeNotFound ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    if (ex.InnerException != null)
                        Console.WriteLine("Details: " + ex.InnerException.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error: " + ex.Message);
                }
            }
        }
    }       
}


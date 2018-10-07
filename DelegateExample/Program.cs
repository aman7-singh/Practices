using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee(printName);
            emp.distpizza();
            Console.ReadKey();
        }
        public static void printName(string name)
        {
            Console.WriteLine(name);
        }
    }

    public class Employee
    {
        public delegate void EmpDel(string name);
        EmpDel obj;
        List<string> empl = new List<string> { "aman", "shubham", "amit", "chotu" };

        public void distpizza()
        {
            foreach (var i in empl)
            {
                obj(i);
            }
        }
        public Employee(EmpDel method)
        {
            obj = method;
        }
    }
}

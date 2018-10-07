using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Emp em = new Emp();
            em.PizzaDist += Em_PizzaDist;
            em.distribute();
            Console.ReadKey();
        }

        private static void Em_PizzaDist(object sender, EmpArgs e)
        {
            Console.WriteLine(e.Name);
        }
    }

    public class Emp
    {
        List<string> empl = new List<string> { "aman", "shubham", "amit", "chotu" };
        public void distribute()
        {
            foreach (var item in empl)
            {
                EmpArgs e = new EmpArgs();
                e.Name = item;
                OnPizzaDist(e);
            }
        }
        public event EventHandler<EmpArgs> PizzaDist;

        public void OnPizzaDist(EmpArgs e)
        {
            var handler = PizzaDist;
            if (handler != null)
            {
                PizzaDist(this, e);
            }
        }
    }
    public class EmpArgs:EventArgs
    {
        public string Name { get; set; }
    }
}

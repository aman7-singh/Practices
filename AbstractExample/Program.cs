using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample
{
    public abstract class abs
    {

        protected int myNumber;
        public abstract int numbers
        {
            get;
            set;
        }

        public abstract void asdf();
        public virtual void asd()
        {
            Console.WriteLine("virtual");
        }
        public abs()
        {
            Console.WriteLine("cons");
        }
    }
    public class absa:abs
    {
        public override int numbers
        {
            get
            {
                return myNumber;
            }
            set
            {
                myNumber = value;
            }
        }


        public override void asdf()
        {
            Console.WriteLine("abstract1");
        }
        //public override void asd()
        //{
        //    Console.WriteLine("virtual1");
        //   // base.asd();
        //}
        public absa()
        {
            Console.WriteLine("cons1");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            abs a = new absa();
            a.asd();
            a.asdf();
            Console.ReadKey();
        }
    }
}

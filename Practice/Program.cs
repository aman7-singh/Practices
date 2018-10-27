using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class LongestSubarrayContiguousElements
    {
        public class A
        {
            public virtual void M()
            {
                Console.WriteLine("AM");

            }

            public A()
            {
                Console.WriteLine("A");
            }
        }
        public class B:A
        {
            public override void M()
            {
                Console.WriteLine("BM");

            }
            public B()
            {
                Console.WriteLine("B");
            }
        }
        public class C:B
        {
            public override void M()
            {
                Console.WriteLine("CM");

            }
            public void Ex()
            {
                throw new Exception();
            }
            public C()
            {
                Console.WriteLine("C");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                A a1 = new A();
                A ab = new B();
                A ac = new C();

                B b1 = new B();
                B bc = new C();

                C c1 = new C();

               // B b2 = (B)new A();
                //C c2 = (C)new B();

                a1.M();
                ab.M();
                ac.M();
                b1.M();
                bc.M();
                c1.M();
                //c1.Ex();
            }
            catch (TypeInitializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            catch
            {
                Console.WriteLine("ex");
            }
            finally
            {
                Console.ReadKey();
            }
            
        }
    }

}

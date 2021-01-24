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
                Console.WriteLine("A a1 = new A()");
                A a1 = new A();
                Console.WriteLine("A ab = new B()");
                A ab = new B();
                Console.WriteLine("A ac = new C()");
                A ac = new C();

                Console.WriteLine("B b1 = new B()");
                B b1 = new B();
                Console.WriteLine(" B bc = new C()");
                B bc = new C();

                Console.WriteLine("C c1 = new C()");
                C c1 = new C();

               // Console.WriteLine("B b2 = (B)new A()");
              //  B b2 = (B)new A();
              //  Console.WriteLine("C c2 = (C)new B()");
              //  C c2 = (C)new B();

                Console.WriteLine("a1.M()");
                a1.M();
                Console.WriteLine("ab.M()");
                ab.M();
                Console.WriteLine("ac.M()");
                ac.M();
                Console.WriteLine("b1.M()");
                b1.M();
                Console.WriteLine("bc.M()");
                bc.M();
                Console.WriteLine("c1.M()");
                c1.M();
               //// Console.WriteLine("c1.Ex()");
               // c1.Ex();
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

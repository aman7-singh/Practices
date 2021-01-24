using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Practice
    {
        public void test()
        {
            SampleClass sample = new SampleClass();
            IControl control = sample;
            ISurface surface = sample;

            // The following lines all call the same method.
            sample.Paint();
            control.Paint();
            surface.Paint();
            // Output:
            // Paint method in SampleClass
            // Paint method in SampleClass
            // Paint method in SampleClass
        }
    }
    public interface IControl
    {
        void Paint();
    }
    public interface ISurface
    {
        void Paint();
    }
    public class SampleClass : IControl, ISurface
    {
        // Both ISurface.Paint and IControl.Paint call this method.
        public void Paint()
        {
            Console.WriteLine("Paint method in SampleClass");
        }
        void IControl.Paint()
        {
            System.Console.WriteLine("IControl.Paint");
        }
        void ISurface.Paint()
        {
            System.Console.WriteLine("ISurface.Paint");
        }

    }
}

using System;
using System.Diagnostics.Contracts;
using System.Linq;
using sd = System.Diagnostics;

namespace IndexVersusPointerInCSharp
{
    class Program
    {
        const int COUNT = 20000;

        static void Main(string[] args)
        {
            //We create the worst case scenario for bubble sort.
            //Thus, the sort will need to make the maximum number of passes and, hence, the maximum number of array access.
            var arr = Enumerable.Range(0, COUNT)
                                .OrderByDescending(i => i);

            var safeSource = arr.ToArray();
            var unsafeSource = arr.ToArray();
            
            Stopwatch(safeSource.SafeBubbleSort, "Safe BubbleSort");
            Stopwatch(unsafeSource.UnsafeBubbleSort, "Unsafe BubbleSort");

            //Asserting the correct results by contract condition.
            Contract.Assert(safeSource.CheckAscendingSort());
            Contract.Assert(unsafeSource.CheckAscendingSort());

            Console.Read();
        }

        static void Stopwatch(Action action, string message)
        {
            var sw = sd.Stopwatch.StartNew();
            action();
            sw.Stop();

            Console.WriteLine("{0} executed in {1} milliseconds.", message, sw.ElapsedMilliseconds);
        }
    }
}

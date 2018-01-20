using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonAppSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var evt = new EventWaitHandle(false, EventResetMode.AutoReset, "MyEvent", out var created);
            if (created)
            {
                Console.WriteLine("Event created");
                for (; ; )
                {
                    var xoxo = evt.WaitOne();
                    Console.WriteLine("WaitOne returned {0}", xoxo);
                }

                evt.Dispose();
            }
            else
            {
                Console.WriteLine("Event not created");
                for (; ; )
                {
                    Console.ReadLine();
                    var set = evt.Set();
                    Console.WriteLine(set);
                }
            }
        }
    }
}

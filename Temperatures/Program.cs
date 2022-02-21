using System;

namespace Temperatures
{
    class Program
    {
        const int CONST_N = 3;
        public static string[] CONST_INPUTS = { "-12", "-5", "-137" };

        static void Main(string[] args)
        {
            int n = CONST_N;//int.Parse(Console.ReadLine()); // the number of temperatures to analyse
            //string[] inputs = Console.ReadLine().Split(' ');
            int res = int.Parse(CONST_INPUTS[0]);
            for (int i = 0; i < n; i++)
            {
                int t = int.Parse(CONST_INPUTS[i]);// a temperature expressed as an integer ranging from -273 to 5526                
                if (Math.Abs(t) < Math.Abs(res))
                {
                    res = t;
                }
                else if (Math.Abs(t) == Math.Abs(res))
                {
                    if (t > 0)
                    {
                        res = t;
                    }
                }
                else if (res == 0)
                {
                    break;
                }
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine("result");
        }
    }
}

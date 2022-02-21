using System;
using System.Collections.Generic;

namespace Horse_racing_Duals
{
    class Program
    {
        const int CONST_N = 3;
        public static int[] CONST_PI = { 5, 8, 9 };

        public static List<int> piList = new List<int>();

        public static void Main(string[] args)
        {
            int N = CONST_N;// int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                piList.Add(CONST_PI[i]);//int.Parse(Console.ReadLine()));
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            piList.Sort();
            int res = piList[1] - piList[0];
            for (int i=1; i<piList.Count; i++)
            {
                if (res == 0)
                {
                    break;
                }
                if ((i+1) < piList.Count) 
                {
                    if ((piList[i + 1] - piList[i]) < res)
                    { 
                        res = piList[i + 1] - piList[i]; 
                    }
                }
            }

            Console.WriteLine(res);
        }
    }
}

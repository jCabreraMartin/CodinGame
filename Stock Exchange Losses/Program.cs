using System;
using System.Collections.Generic;

namespace Stock_Exchange_Losses
{
    class Program
    {
        #region INPUT
        const int c_n = 6;
        public static int[] c_v = { 5, 3, 4, 2, 3, 1 };
        #endregion

        public static List<int> vList = new List<int>();

        static void Main(string[] args)
        {
            int output = 0;
            int n = c_n; //int.Parse(Console.ReadLine());
            //string[] inputs = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                int v = c_v[i]; //int.Parse(inputs[i]);
                vList.Add(v);
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            int max = vList[0];
            int min = vList[0];
            List<int> bajadasList = new List<int>();

            for (int i=1; i<vList.Count; i++)
            {
                if(max < vList[i])
                { 
                    bajadasList.Add(min-max);
                    max = vList[i];
                    min = vList[i];
                }
                if(min > vList[i])
                {
                    min = vList[i];
                }
            }

            if (bajadasList.Count == 0)
            {
                bajadasList.Add(min - max);
            }

            foreach (int _b in bajadasList)
            {
                if (_b < output)
                {
                    output = _b;
                }
            }

            Console.WriteLine(output);
        }
    }
}

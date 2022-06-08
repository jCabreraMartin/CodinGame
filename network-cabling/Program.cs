using System;
using System.Collections.Generic;
using System.Linq;

namespace network_cabling
{
    class Program
    {
        #region INPUTS
        const int N = 8;
        //public static string[] coordendas = { "0 0", "1 1", "2 2" };
        //public static string[] coordendas = { "1 2", "0 0", "2 2" };
        //public static string[] coordendas = { "1 2", "0 0", "2 2", "1 3" };
        //public static string[] coordendas = { "1 1" };
        //public static string[] coordendas = { "-5 -3", "-9 2", "3 -4" };
        public static string[] coordendas = { "-28189131 593661218", "102460950 1038903636", "938059973 -816049599", "-334087877 -290840615", "842560881 -116496866", "-416604701 690825290", "19715507 470868309", "846505116 -694479954" };
        #endregion

        public static List<int> listX = new List<int>();
        public static List<int> listY = new List<int>();

        static void Main(string[] args)
        {
            //int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                //string[] inputs = Console.ReadLine().Split(' ');
                string[] inputs = coordendas[i].Split(' ');
                listX.Add(int.Parse(inputs[0]));
                listY.Add(int.Parse(inputs[1]));
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            Int64 longCable = 0;
            if (N > 1)
            {
                //Calcular cable principal
                int mainCable = 2;
                int tmp = 1;
                bool calculateMedia = true;
                int index = 0;
                foreach (var item in listY.OrderBy(x => x).GroupBy(x => x)) 
                { 
                    if (calculateMedia && index.Equals(listY.Count/2))
                    {
                        //mainCable = listY.Sum(x => x)/listY.Count;
                        mainCable = item.Key;
                    }

                    if (item.Count() > tmp)
                    {
                        tmp = item.Count();
                        mainCable = item.Key;
                        calculateMedia = false;
                    }
                    index++;
                }
                //final del cable principal
                int firstHouse = listX.OrderBy(x => x).FirstOrDefault();
                int lastHouse = listX.OrderByDescending(x => x).FirstOrDefault();

                longCable = Math.Abs(firstHouse) + Math.Abs(lastHouse);
                for(int i = 0; i < N; i++)
                {
                    if(listY[i] != mainCable)
                    {
                        if ((mainCable < 0 && listY[i] < 0) || (mainCable >= 0 && listY[i] >= 0))
                        {
                            longCable += Math.Abs(mainCable - listY[i]);
                        }
                        else if ((mainCable < 0 && listY[i] >= 0) || (mainCable >= 0 && listY[i] < 0))
                        {
                            longCable += Math.Abs(mainCable) + Math.Abs(listY[i]);
                        }
                    }
                }

            }

            Console.WriteLine(longCable);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Defibrillators
{
    class Program
    {
        // INPUT
        const string USER_LON = "3,879483";
        const string USER_LAT = "43,608177";
        const int DESF_NUMBER = 3;
        public static string[] DESF = { "1;Maison de la Prevention Sante;6 rue Maguelone 340000 Montpellier;;3,87952263361082;43,6071285339217",
"2;Hotel de Ville;1 place Georges Freche 34267 Montpellier;;3,89652239197876;43,5987299452849",
"3;Zoo de Lunaret;50 avenue Agropolis 34090 Mtp;;3,87388031141133;43,6395872778854" };

        const int MAX_DISTANCE = -1;

        public class desfibrilador {
            public int id { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public double longitud { get; set; }
            public double latitud { get; set; }
        }

        public static List<desfibrilador> desfList = new List<desfibrilador>();

        public static void Main(string[] args)
        {
            string LON = USER_LON; //Console.ReadLine();
            string LAT = USER_LAT; //Console.ReadLine();
            int N = DESF_NUMBER; //int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string DEFIB = DESF[i]; //Console.ReadLine();
                desfList.Add(serializeDefib(DEFIB));
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            double distance = MAX_DISTANCE;
            string desfName = desfList[0].name;
            foreach (desfibrilador d in desfList)
            {
                double distanceTmp = calculateDistance(double.Parse(LON), double.Parse(LAT), d);
                if (distanceTmp < distance || distance.Equals(MAX_DISTANCE))
                {
                    distance = distanceTmp;
                    desfName = d.name;
                }
            }

            Console.WriteLine(desfName);
        }

        private static double calculateDistance(double lON, double lAT, desfibrilador d)
        {
            double x = (d.longitud - lON) * Math.Cos((lAT + d.latitud) / 2);
            double y = d.latitud - lAT;
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * 6371;
            return distance;
        }

        private static desfibrilador serializeDefib(string dEFIB)
        {
            string[] temp = dEFIB.Split(';');

            desfibrilador desf = new desfibrilador();
            desf.id = int.Parse(temp[0]);
            desf.name = temp[1];
            desf.address = temp[2];
            desf.phone = temp[3];
            desf.longitud = double.Parse(temp[4].Replace(',', '.'));
            desf.latitud = double.Parse(temp[5].Replace(',', '.'));

            return desf;
        }
    }
}

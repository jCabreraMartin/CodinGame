using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace MimeType
{
    class Program
    {
        public class nodo 
        {
            public string ext;
            public string mt;

            public nodo(string ext, string mt)
            {
                this.ext = ext;
                this.mt = mt;
            }
        }

        public static List<nodo> table = new List<nodo>();

        static void Main(string[] args)
        {
            Console.WriteLine("N: ");
            int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
            Console.WriteLine("Q: ");
            int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(',');
                table.Add(new nodo(inputs[0].Trim(), inputs[1].Trim()));
            }

            for (int i = 0; i < Q; i++)
            {
                string FNAME = Console.ReadLine(); // One file name per line.                
                Console.Error.WriteLine("FNAME: " + FNAME);
                if (FNAME.Contains('.'))
                {
                    string[] FNAME_EXT = FNAME.Split('.');
                    string res = searchInTableOptimized(FNAME_EXT[(FNAME_EXT.Length) - 1]);
                    Console.WriteLine(res);
                }
                else
                {
                    Console.WriteLine("UNKNOWN");
                }
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // For each of the Q filenames, display on a line the corresponding MIME type. If there is no corresponding type, then display UNKNOWN.
            //Console.WriteLine("UNKNOWN");
        }

        private static string searchInTableOptimized(string ext)
        {
            nodo res = table.Where(x => x.ext.ToUpper() == ext.ToUpper()).FirstOrDefault();
            
            if (res == null)
            {
                return "UNKNOWN";
            }
            else
            {
                return res.mt;
            }
        }

        //private static string searchInTable(string ext)
        //{
        //    foreach (nodo n in table)
        //    {
        //        if (n.ext.Equals(ext))
        //        {
        //            return n.mt;
        //        }
        //    }
        //    return "UNKNOWN";
        //}
    }
}

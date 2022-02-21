using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    public static List<link> enlaces = new List<link>();
    public static List<int> gatewayList = new List<int>();

    public class link
    {
        public link(int n1, int n2)
        {
            N1 = n1;
            N2 = n2;
        }

        public int N1 { get; set; }
        public int N2 { get; set; }
    }

    public static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        Console.Error.WriteLine(string.Format("N: {0}, L: {1}, E: {2}", N, L, E));
        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            enlaces.Add(new link(N1, N2));
            Console.Error.WriteLine(string.Format("N1: {0}, N2: {1}", N1, N2));
        }
        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            gatewayList.Add(EI);
            Console.Error.WriteLine(string.Format("EI: {0}", EI));
        }

        // game loop
        string res = string.Empty;
        int j = 0;
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn
            Console.Error.WriteLine(string.Format("SI: {0}", SI));

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            foreach (int gateway in gatewayList)
            {
                if (existLink(SI, gateway))
                {
                    res = SI.ToString() + " " + gateway.ToString();
                }
                else if (existLink(gateway, SI))
                {
                    res = gateway.ToString() + " " + SI.ToString();
                }
            }

            if (string.IsNullOrEmpty(res))
            {
                if (existLink(SI, SI + 1))
                {
                    res = SI.ToString() + " " + (SI + 1).ToString();
                }
                else if (existLink(SI + 1, SI))
                {
                    res = (SI + 1).ToString() + " " + SI.ToString();
                }
                else if (existLink(SI, SI - 1))
                {
                    res = SI.ToString() + " " + (SI - 1).ToString();
                }
                else if (existLink(SI - 1, SI))
                {
                    res = (SI - 1).ToString() + " " + SI.ToString();
                }
                else
                {
                    res = enlaces[j].N1.ToString() + " " + enlaces[j].N2.ToString();
                    j++;
                }
            }

            // Example: 0 1 are the indices of the nodes you wish to sever the link between
            Console.WriteLine(res);
        }
    }

    private static bool existLink(int sI, int gateway)
    {
        foreach (var link in enlaces)
        {
            link tmpLink = new link(sI, gateway);
            if (tmpLink.N1.Equals(link.N1) && tmpLink.N2.Equals(link.N2))
            {
                return true;
            }
        }
        return false;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Death_First_Search___Episode_1
{
    class Program
    {
        const int CONS_N = 8;
        const int CONS_L = 13;
        const int CONS_E = 2;
        public static int[] CONS_N1 = { 6, 7, 6, 5, 3, 7, 2, 0, 0, 1, 2, 7, 6 };
        public static int[] CONS_N2 = { 2, 3, 3, 3, 4, 1, 0, 1, 3, 3, 3, 4, 5 };
        public static int[] CONS_EI = { 4, 5 };
        public static int[] CONS_SI = { 0, 3, 6, 3 };

        public class link
        {
            public int N1 { get; set; }
            public int N2 { get; set; }
            public bool Locked { get; set; }

            public link(int n1, int n2, bool locked)
            {
                N1 = n1;
                N2 = n2;
                Locked = locked;
            }
        }
        public class nodo
        {
            public int Name { get; set; }
            public List<link> Aristas { get; set; }
            public bool IsGateway { get; set; }
            public bool IsVirus { get; set; }
            public nodo(int _n, List<link> _a, bool _g, bool _v)
            {
                Name = _n;
                Aristas = _a;
                IsGateway = _g;
                IsVirus = _v;
            }
        }

        public class Line
        {
            public int Weight { get; set; }
            public List<link> Path { get; set; }

            public Line(int _w, List<link> _p)
            {
                Weight = _w;
                Path = _p;
            }
        }

        public static List<int> gatewayList = new List<int>();
        public static List<link> enlace = new List<link>();
        public static List<nodo> nodos = new List<nodo>();

        static void Main(string[] args)
        {
            //string[] inputs;
            //inputs = Console.ReadLine().Split(' ');
            int N = CONS_N;// int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
            int L = CONS_L;// int.Parse(inputs[1]); // the number of links
            int E = CONS_E;// int.Parse(inputs[2]); // the number of exit gateways

            link _link = null;
            for (int i = 0; i < L; i++)
            {
                //inputs = Console.ReadLine().Split(' ');
                //enlace.Add(new link(CONS_N1[i], CONS_N2[i], false)); // N1 and N2 defines a link between these nodes
                _link = new link(CONS_N1[i], CONS_N2[i], false);
                if (nodos.Count == 0)
                {
                    insertNodo(CONS_N1[i], _link);
                    insertNodo(CONS_N2[i], _link);
                }
                else
                {
                    if (existeNodo(CONS_N1[i]))
                    {
                        updateNodo(CONS_N1[i], _link);
                    }
                    else
                    {
                        insertNodo(CONS_N1[i], _link);
                    }

                    if (existeNodo(CONS_N2[i]))
                    {
                        updateNodo(CONS_N2[i], _link);
                    }
                    else
                    {
                        insertNodo(CONS_N2[i], _link);
                    }
                }
            }
            for (int i = 0; i < E; i++)
            {
                //gatewayList.Add(CONS_EI[i]); //int.Parse(Console.ReadLine()); // the index of a gateway node
                updateGateway(CONS_EI[i]);
            }

            // game loop
            for (int i = 0; i < CONS_SI.Length; i++)
            {
                int SI = CONS_SI[i];//int.Parse(Console.ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn                
                updateVirus(SI);
                string res;
                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");                
                res = closedLink(SI);
                // Example: 0 1 are the indices of the nodes you wish to sever the link between
                Console.WriteLine(res);
            }
        }

        private static void updateVirus(int sI)
        {
            nodos.Where(x => x.Name != sI).ToList().ForEach(f => f.IsVirus = false);
            nodos.Where(x => x.Name == sI).ToList().ForEach(f => f.IsVirus = true);
        }

        private static string closedLink(int sI)
        {
            string enlace = string.Empty;
            // 'SI' esta al lado de un 'gateway' - Cerrar el link entre ambos puntos
            foreach (nodo _n in nodos)
            {
                if (_n.IsGateway)
                {
                    foreach (link _l in _n.Aristas)
                    {
                        if (!_l.Locked && (_l.N1.Equals(sI) || _l.N2.Equals(sI)))
                        {
                            _l.Locked = true;
                            return _l.N1 + " " + _l.N2;
                        }
                    }
                }
            }

            // 'SI' no esta al lado de un 'gateway' - Cerrar el link con menos nodos hasta 'SI'
            List<Line> lineList = new List<Line>();
            foreach (nodo _n in nodos)
            {
                if (_n.IsGateway)
                {
                    lineList = CalculateDistances(_n, sI, lineList);
                }
            }
            // Recuperar el enlace del camino más corto
            // enlace = caminoMasCorto(lineList);
            return enlace;
        }

        private static List<Line> CalculateDistances(nodo nGateway, int sI, List<Line> lineList)
        {
            return null;
        }

        private static int CalculateDistance(nodo n, int sI, int dist, out string enlace)
        {
            enlace = string.Empty;
            for (int i = 0; i < n.Aristas.Count; i++)
            {
                if (n.Aristas[i].N1.Equals(sI) || n.Aristas[i].N2.Equals(sI))
                {
                    dist = i + 1;
                    n.Aristas[i].Locked = true;
                    enlace = n.Aristas[i].N1 + " " + n.Aristas[i].N2;
                    break;
                }
                else if (n.Aristas.Count.Equals(i + 1))
                {
                    dist++;
                    foreach (nodo _n in nodos)
                    {
                        if (!_n.Name.Equals(n.Name) && isNextToCurrentNodo(n, _n))
                        {
                            dist = CalculateDistance(_n, sI, dist, out enlace);
                        }
                    }
                }
            }
            return dist;
        }

        private static bool isNextToCurrentNodo(nodo currentNodo, nodo nextNodo)
        {
            foreach (link l in currentNodo.Aristas)
            {
                if (l.N1.Equals(nextNodo.Name) || l.N2.Equals(nextNodo.Name))
                {
                    return true;
                }
            }
            return false;
        }

        private static void updateGateway(int g)
        {
            nodos.Where(x => x.Name == g).ToList().ForEach(f => f.IsGateway = true);
        }

        private static void updateNodo(int n, link link)
        {
            nodos.Where(x => x.Name == n).ToList().ForEach(f => f.Aristas.Add(link));
        }

        private static void insertNodo(int n, link link)
        {
            List<link> _arista = new List<link>();

            _arista.Add(link);
            nodos.Add(new nodo(n, _arista, false, false));
        }

        private static bool existeNodo(int n)
        {
            foreach (nodo _n in nodos)
            {
                if (n.Equals(_n.Name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

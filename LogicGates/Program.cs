using System;
using System.Collections.Generic;

namespace LogicGates
{
    class Program
    {
        #region Input
        const int c_n = 2;
        const int c_m = 3;
        public static string[] nArray = { "A __---___---___---___---___", "B ____---___---___---___---_" };
        public static string[] mArray = { "C AND A B", "D OR A B", "E XOR A B" };
        #endregion

        public class signalInput
        {
            public string name { get; set; }
            public List<bool> signal { get; set; }

            public signalInput(string n1, List<bool> n2)
            {
                name = n1;
                signal = n2;
            }
        }

        public static List<signalInput> inputSignalList = new List<signalInput>();

        public static List<string> outputNameList = new List<string>();
        public static List<string> typeList = new List<string>();
        public static List<string> inputName1 = new List<string>();
        public static List<string> inputName2 = new List<string>();

        static void Main(string[] args)
        {
            string[] inputs;
            int n = c_n;
            int m = c_m;
            for (int i = 0; i < n; i++)
            {
                inputs = nArray[i].Split(' ');
                inputSignalList.Add(new signalInput(inputs[0], EncodeSignal(inputs[1])));
            }
            for (int i = 0; i < m; i++)
            {
                inputs = mArray[i].Split(' ');
                outputNameList.Add(inputs[0]);
                typeList.Add(inputs[1]);
                inputName1.Add(inputs[2]);
                inputName2.Add(inputs[3]);
            }
            for (int i = 0; i < m; i++)
            {
                // Write an answer using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");
                string res = outputNameList[i] + " " + calculateOutput(typeList[i], inputName1[i], inputName2[i]);

                Console.WriteLine(res);
            }
        }

        private static List<bool> EncodeSignal(string signal)
        {
            List<bool> res = new List<bool>();
            for(int i=0; i<signal.Length; i++)
            {
                if (signal[i].Equals('-'))
                {
                    res.Add(true);
                }
                else if (signal[i].Equals('_'))
                {
                    res.Add(false);
                }
            }
            return res;
        }

        private static string DecodeSignal(List<bool> signal)
        {
            string res = string.Empty;
            foreach(bool val in signal)
            {
                if (val)
                {
                    res += "-";
                }
                else 
                {
                    res += "_";
                }
            }
            return res;
        }

        private static string calculateOutput(string operacion, string input1, string input2)
        {
            List<bool> op1 = getSignalInput(input1);
            List<bool> op2 = getSignalInput(input2);
            List<bool> res = new List<bool>();

            switch (operacion)
            {
                case "AND":
                    for(int i=0; i<op1.Count; i++)
                    {
                        res.Add(op1[i] & op2[i]);
                    }
                    break;
                case "OR":
                    for (int i = 0; i < op1.Count; i++)
                    {
                        res.Add(op1[i] | op2[i]);
                    }
                    break;
                case "XOR":
                    for (int i = 0; i < op1.Count; i++)
                    {
                        res.Add(op1[i] ^ op2[i]);
                    }
                    break;
                case "NAND":
                    for (int i = 0; i < op1.Count; i++)
                    {
                        res.Add(!(op1[i] & op2[i]));
                    }
                    break;
                case "NOR":
                    for (int i = 0; i < op1.Count; i++)
                    {
                        res.Add(!(op1[i] | op2[i]));
                    }
                    break;
                case "NXOR":
                    for (int i = 0; i < op1.Count; i++)
                    {
                        res.Add(!(op1[i] ^ op2[i]));
                    }
                    break;
            }
            return DecodeSignal(res);
        }

        private static List<bool> getSignalInput(string input)
        {
            foreach(signalInput _input in inputSignalList)
            {
                if (_input.name.Equals(input))
                {
                    return _input.signal;
                }
            }
            return null;
        }
    }
}

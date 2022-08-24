using System;

namespace the_fall_episode_1
{
    class Program
    {
        #region INPUTS
        const int W = 2; 
        const int H = 4;
        public static string[] input = new string[] { "4 3", "12 10", "11 5", "2 3" };
        public static string[] nextLine = new string[] { "1 0 TOP", "1 1 TOP" };
        #endregion

        public static string[,] mygrid = new string[W, H];

        public static void Main(string[] args)
        {
            string[] inputs;
            //inputs = Console.ReadLine().Split(' ');
            //int W = int.Parse(inputs[0]); // number of columns.
            //int H = int.Parse(inputs[1]); // number of rows.

            for (int i = 0; i < H; i++)
            {
                string LINE = input[i]; //Console.ReadLine(); // represents a line in the grid and contains W integers. Each integer represents one room of a given type.
                for (int j = 0; j < W; j++)
                {
                    mygrid[j, i] = LINE.Split(" ")[j];
                }
            }
            //int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).

            int index = 0;
            // game loop
            while (true)
            {
                //inputs = Console.ReadLine().Split(' ');
                inputs = nextLine[index].Split(' ');
                int XI = int.Parse(inputs[0]);
                int YI = int.Parse(inputs[1]);
                string POS = inputs[2];
                string nextPos;
                string output = string.Empty;

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");
                nextPos = searchOutput(XI, YI, POS);

                switch (nextPos)
                {
                    case "DOWN":
                        output = string.Format("{0} {1}", XI, YI+1);
                        break;
                    case "LEFT":
                        output = string.Format("{0} {1}", XI-1, YI);
                        break;
                    case "RIGHT":
                        output = string.Format("{0} {1}", XI+1, YI);
                        break;
                    default: break;
                }

                index++;
                // One line containing the X Y coordinates of the room in which you believe Indy will be on the next turn.
                Console.WriteLine(output);
            }
        }

        private static string searchOutput(int xi, int yi, string pos)
        {
            string typeCell = mygrid[xi, yi];
            switch (typeCell)
            {
                case "0":
                    return string.Empty;
                case "1":
                    if (pos.Equals("TOP") || pos.Equals("LEFT") || pos.Equals("RIGHT")) 
                    {
                        return "DOWN";
                    }
                    else
                    {
                        return string.Empty;
                    }
                case "2":
                    if (pos.Equals("LEFT"))
                    {
                        return "RIGHT";
                    }
                    else if (pos.Equals("RIGHT"))
                    {
                        return "LEFT";
                    }
                    else
                    {
                        return string.Empty;
                    }
                case "12":
                    if (pos.Equals("RIGHT"))
                    {
                        return "DOWN";
                    }
                    else
                    {
                        return string.Empty;
                    }
                default:
                    return string.Empty;
            }
        }
    }
}

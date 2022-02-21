using System;
using System.Collections.Generic;
using System.Linq;

namespace DON_T_PANIC___EPISODE_1
{
    class Program
    {
        #region INPUTS
        const int c_nbFloors = 7;
        const int c_width = 24; 
        const int c_nbRounds = 200;
        const int c_exitFloor = 6;
        const int c_exitPos = 17;
        const int c_nbTotalClones = 40;
        const int c_nbAdditionalElevators = 0;
        const int c_nbElevators = 6;
        public static int[] c_elevatorFloor = { 3, 5, 2, 0, 1, 4 };
        public static int[] c_elevatorPos = { 18, 12, 6, 14, 10, 15 };
        public static int[] c_cloneFloor = { 0, 0, 0 };
        public static int[] c_clonePos = { 17, 18, 19 };
        public static string[] c_direction = { "RIGHT", "RIGHT", "RIGHT" };
        #endregion

        public class Elevator
        {
            public int Floor { get; set; }
            public int Pos { get; set; }

            public Elevator(int f, int p)
            {
                Floor = f;
                Pos = p;
            }
        }

        static void Main(string[] args)
        {
            string[] inputs;
            //inputs = Console.ReadLine().Split(' ');
            int nbFloors = c_nbFloors; // number of floors
            int width = c_width; // width of the area
            int nbRounds = c_nbRounds; // maximum number of rounds
            int exitFloor = c_exitFloor; // floor on which the exit is found
            int exitPos = c_exitPos; // position of the exit on its floor
            int nbTotalClones = c_nbTotalClones; // number of generated clones
            int nbAdditionalElevators = c_nbAdditionalElevators; // ignore (always zero)
            int nbElevators = c_nbElevators; // number of elevators

            List<Elevator> elevator = new List<Elevator>();

            for (int i = 0; i < nbElevators; i++)
            {
                //inputs = Console.ReadLine().Split(' ');
                elevator.Add(new Elevator(c_elevatorFloor[i], c_elevatorPos[i])); // floor on which this elevator is found          
            }

            // game loop
            int j = 0;
            while (true)
            {
                string output = "WAIT";
                //inputs = Console.ReadLine().Split(' ');
                int cloneFloor = c_cloneFloor[j]; // floor of the leading clone
                int clonePos = c_clonePos[j]; // position of the leading clone on its floor
                string direction = c_direction[j]; // direction of the leading clone: LEFT or RIGHT
                bool existClone = cloneFloor != -1 && clonePos != -1 && !direction.Equals("NONE");

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");
                if (existClone) 
                { 
                    if (nbElevators == 0 || exitFloor == cloneFloor)
                    {
                        if (direction.Equals("RIGHT"))
                        {
                            if (exitPos < clonePos)
                            {
                                output = "BLOCK";
                            }
                        }
                        else
                        {
                            if (exitPos > clonePos)
                            {
                                output = "BLOCK";
                            }
                        }
                    }
                    else
                    {
                        Elevator exitElevator = elevator.Where(x => x.Floor == cloneFloor).FirstOrDefault();
                        if (direction.Equals("RIGHT"))
                        {
                            if (exitElevator.Pos < clonePos)
                            {
                                output = "BLOCK";
                            }
                        }
                        else
                        {
                            if (exitElevator.Pos > clonePos)
                            {
                                output = "BLOCK";
                            }
                        }
                    }
                }

                Console.WriteLine(output); // action: WAIT or BLOCK
                j++;
            }
        }
    }
}

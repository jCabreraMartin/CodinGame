using System;

namespace CodersStrikeBack
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs;
            bool boost = true;
            string thrust = " 100";

            // game loop
            while (true)
            {
                inputs = Console.ReadLine().Split(' ');
                int x = int.Parse(inputs[0]);
                int y = int.Parse(inputs[1]);
                int nextCheckpointX = int.Parse(inputs[2]); // x position of the next check point
                int nextCheckpointY = int.Parse(inputs[3]); // y position of the next check point
                int nextCheckpointDist = int.Parse(inputs[4]); // distance to the next checkpoint
                int nextCheckpointAngle = int.Parse(inputs[5]); // angle between your pod orientation and the direction of the next checkpoint
                inputs = Console.ReadLine().Split(' ');
                int opponentX = int.Parse(inputs[0]);
                int opponentY = int.Parse(inputs[1]);

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");

                // You have to output the target position
                // followed by the power (0 <= thrust <= 100)
                // i.e.: "x y thrust"
                if (nextCheckpointAngle > 90 || nextCheckpointAngle < -90)
                {
                    thrust = " 0";
                }
                else if (nextCheckpointAngle > 65 || nextCheckpointAngle < -65)
                {
                    thrust = " 70";
                }
                else
                {
                    if (nextCheckpointDist > 5500 && boost)
                    {
                        thrust = " BOOST";
                        boost = false;
                    }
                    else if (nextCheckpointDist < 1800 && nextCheckpointDist > 800)
                    {
                        thrust = " 60";
                    }
                    else if (nextCheckpointDist <= 800)
                    {
                        thrust = " 40";
                    }
                    else
                    {
                        thrust = " 100";
                    }
                }
                Console.Error.WriteLine("nextCheckpointAngle " + nextCheckpointAngle);
                Console.Error.WriteLine("nextCheckpointDist " + nextCheckpointDist);
                Console.Error.WriteLine("thrust " + thrust + " (" + boost + ")");
                Console.WriteLine(nextCheckpointX + " " + nextCheckpointY + thrust);
            }
        }
    }
}

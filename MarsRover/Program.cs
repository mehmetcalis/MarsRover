using System;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WellCome The Mars, Enter your research area!(X Y)");
            var reseachArea = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            Console.WriteLine("Enter Rover Position");
            var firstPosition = Console.ReadLine().Trim().Split(' ');

            MotionControl control = new MotionControl();

            if (firstPosition.Count() == 3)
            {
                control.X = Convert.ToInt32(firstPosition[0]);
                control.Y = Convert.ToInt32(firstPosition[1]);
                control.Direction = (Directions)Enum.Parse(typeof(Directions), firstPosition[2]);
            }

            Console.WriteLine("Define To Rover Movement");
            var moves = Console.ReadLine().ToUpper();

            try
            {
                control.StartMoving(reseachArea, moves);
                Console.WriteLine($"{control.X} {control.Y} {control.Direction.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}

using HBRoverApp.Base;
using HBRoverApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HBRoverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rover rover = new Rover();
            Vehicle rover;


            List<int> borders = new List<int>();
            //Get the Plateaus Borders
            while (true)
            {
                try
                {
                    Console.Write("Enter The Plateau Max Border İnfo (exmp:5 5):");
                    borders = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

                    if (borders.Count() > 1)
                    {
                        Plateau.XBorder = borders[0];
                        Plateau.YBorder = borders[1];
                        break;
                    }
                }
                catch
                {

                }
            }


            while (true)
            {
                string[] startDirections;
                rover = new Rover();
                // Get the first position of Rover on plateu
                //while (true)
                //{

                Console.Write("Enter The First Position Information (exmp: 1 2 N):");
                startDirections = Console.ReadLine().Trim().Split(' ');
                //Console.WriteLine("The Rovers Position: " + Convert.ToInt32(startDirections[0]) + " " + Convert.ToInt32(startDirections[1]) + " " + startDirections[2]);

                //Get direction from Char
                rover.Direction = (Directions)Char.Parse(startDirections[2]);

                //get the direction enum as list
                var directionList = Enum.GetValues(typeof(Directions)).Cast<Directions>();

                int _xPosition = 0, _yPosition = 0;

                Int32.TryParse(startDirections[0], out _xPosition);
                Int32.TryParse(startDirections[1], out _yPosition);

                if (_xPosition < 0 || _xPosition > Plateau.XBorder || _yPosition < 0 || _yPosition > Plateau.YBorder)
                {
                    Console.WriteLine("First position can not be out of Plateau borders");
                    continue;
                }
                rover.XPosition = _xPosition;
                rover.YPosition = _yPosition;

                if (directionList.Contains(rover.Direction))
                {
                    Console.WriteLine("The Rovers Position: " + Convert.ToInt32(startDirections[0]) + " " + Convert.ToInt32(startDirections[1]) + " " + startDirections[2]);
                }



                //}
                //Get The Movement Commands
                Console.Write("Enter The Movement Commands:");
                var command = Console.ReadLine().Replace(" ", "").ToUpper();

                bool exitloop = false;
                foreach (var item in command)
                {

                    switch (item)
                    {
                        case 'M':
                            if (!rover.Move())
                            {
                                exitloop = true;
                            }
                            break;
                        case 'L':
                            rover.TurnLeft();
                            break;
                        case 'R':
                            rover.TurnRight();
                            break;
                        default://if the command is out of M ,L and R
                            Console.WriteLine($"Invalid Character {item}");
                            break;

                    }
                    if (exitloop)
                    {
                        //Print Position of Rover Before Crash the Border of Plateau
                        Console.WriteLine("The Commands You Entered Lets the Rover to be out of the Plateou. Last Position of Rover:" + rover.XPosition.ToString() + " " + rover.YPosition.ToString() + " " + rover.Direction);

                        break;
                    }
                }
                //Print Position of Rover
                if (!exitloop)
                    Console.WriteLine("Position:" + rover.XPosition.ToString() + " " + rover.YPosition.ToString() + " " + rover.Direction);
                Console.Write("Press Q to Finish or Press Enter to Continue for Another Rover: ");
                var exitConfirm = Console.ReadLine();

                if (exitConfirm.ToUpper() == "Q")
                    break;
            }
            Environment.Exit(0);
        }



    }
}

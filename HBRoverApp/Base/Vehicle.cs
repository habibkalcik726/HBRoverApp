using HBRoverApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBRoverApp.Base
{
    public abstract class Vehicle : IMove
    {


        public Directions Direction { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public abstract bool Move();

        public abstract void TurnLeft();


        public abstract void TurnRight();

    }


    public enum Directions
    {
        North = 'N',
        South = 'S',
        East = 'E',
        West = 'W'

    }
}

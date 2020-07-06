using HBRoverApp.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBRoverApp.Models
{
    public class Rover : Vehicle,IMove
    {

        public Rover(int xPosition, int yPosition, Directions direction)
        {
            this.XPosition = xPosition;
            this.YPosition = xPosition;
            this.Direction = direction;
        }

        public Rover()
        {
        }


        /// <summary>
        /// Moves The Rovers on the current Direction
        /// </summary>
        public override bool Move()
        {

            int Step = 1;
            var previusX = this.XPosition;
            var previusY = this.YPosition;


            switch (this.Direction)
            {

                case Directions.East:
                    this.XPosition = this.XPosition + Step;
                    break;

                case Directions.North:
                    this.YPosition = this.YPosition + Step;
                    break;

                case Directions.West:
                    this.XPosition = this.XPosition - Step;
                    break;

                case Directions.South:
                    this.YPosition = this.YPosition - Step;
                    break;

            }
            //If rover get out of the border.
            if (this.XPosition > Plateau.XBorder || this.YPosition > Plateau.YBorder
                    || this.XPosition < 0 || this.YPosition < 0)
            {
                this.XPosition = previusX;
                this.YPosition = previusY;
                return false;
            }
            return true;
        }
        /// <summary>
        /// Change the Rovers Direction to Left 
        /// </summary>
        public override void TurnLeft()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Direction = Directions.West;
                    break;
                case Directions.West:
                    this.Direction = Directions.South;
                    break;
                case Directions.South:
                    this.Direction = Directions.East;
                    break;
                case Directions.East:
                    this.Direction = Directions.North;
                    break;

            }
        }

        /// <summary>
        /// Change the Rovers Direction to Right 
        /// </summary>
        public override void TurnRight()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Direction = Directions.East;
                    break;
                case Directions.West:
                    this.Direction = Directions.North;
                    break;
                case Directions.South:
                    this.Direction = Directions.West;
                    break;
                case Directions.East:
                    this.Direction = Directions.South;
                    break;

            }
        }

      
    }

}

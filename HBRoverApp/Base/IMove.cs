using System;
using System.Collections.Generic;
using System.Text;

namespace HBRoverApp.Models
{
    public interface IMove
    {
        bool Move();
        void TurnLeft();
        void TurnRight();
    }
}

using HepsiBurada.MarsRover.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.BusinessModel.Model
{
    public class RoverPosition
    {
        public RoverPosition()
        {
            XPosition = 0;
            YPosition = 0;
            CurrentDirectionType = DirectionType.N;
        }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public DirectionType CurrentDirectionType { get; set; }
    }
}

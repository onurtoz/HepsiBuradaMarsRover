using System;
using System.Collections.Generic;
using System.Text;
using HepsiBurada.MarsRover.BusinessModel.Model;
using HepsiBurada.MarsRover.Common.Enum;

namespace HepsiBurada.MarsRover.BusinessServices.Services.RoverNavigate
{
    public class MoveNavigate : IRoverNavigate
    {
        public void Navigate(RoverPosition roverPosition)
        {

            switch (roverPosition.CurrentDirectionType)
            {
                case DirectionType.N:
                    roverPosition.YPosition += 1;
                    break;
                case DirectionType.S:
                    roverPosition.YPosition -= 1;
                    break;
                case DirectionType.E:
                    roverPosition.XPosition += 1;
                    break;
                case DirectionType.W:
                    roverPosition.XPosition -= 1;
                    break;
                default:
                    break;
            }

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using HepsiBurada.MarsRover.BusinessModel.Model;
using HepsiBurada.MarsRover.Common.Enum;

namespace HepsiBurada.MarsRover.BusinessServices.Services.RoverNavigate
{
    public class LeftNavigate : IRoverNavigate
    {
        public void Navigate(RoverPosition roverPosition)
        {
            switch (roverPosition.CurrentDirectionType)
            {
                case DirectionType.N:
                    roverPosition.CurrentDirectionType = DirectionType.W;
                    break;
                case DirectionType.E:
                    roverPosition.CurrentDirectionType = DirectionType.N;
                    break;

                case DirectionType.S:
                    roverPosition.CurrentDirectionType = DirectionType.E;
                    break;

                case DirectionType.W:
                    roverPosition.CurrentDirectionType = DirectionType.S;
                    break;
            }
        }
    }
}

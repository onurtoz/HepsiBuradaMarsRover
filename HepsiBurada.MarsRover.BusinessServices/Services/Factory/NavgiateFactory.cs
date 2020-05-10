using System;
using System.Collections.Generic;
using System.Text;
using HepsiBurada.MarsRover.BusinessServices.Services.RoverNavigate;
using HepsiBurada.MarsRover.Common.Enum;

namespace HepsiBurada.MarsRover.BusinessServices.Services.Factory
{
    public class NavgiateFactory : INavgiateFactory
    {
        public IRoverNavigate GetRoverNavigate(CommandType commandType)
        {
            IRoverNavigate roverNavigate = null;
            switch (commandType)
            {
                case CommandType.M:
                    roverNavigate = new MoveNavigate();
                    break;
                case CommandType.L:
                    roverNavigate = new LeftNavigate();
                    break;
                case CommandType.R:
                    roverNavigate = new RightNavigate();
                    break;
                default:
                    break;
             }
            return roverNavigate;
        }
    }
}

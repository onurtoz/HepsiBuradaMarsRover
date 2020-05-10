using HepsiBurada.MarsRover.BusinessServices.Services.RoverNavigate;
using HepsiBurada.MarsRover.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.BusinessServices.Services.Factory
{
    public interface INavgiateFactory
    {
        IRoverNavigate GetRoverNavigate(CommandType commandType);
    }
}

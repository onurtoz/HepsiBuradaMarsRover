using HepsiBurada.MarsRover.BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.BusinessServices.Services.RoverService
{
    public interface IRoverService
    {
        Rover PositionMove(Instruction ınstruction, Rover rover);
       
    }
}

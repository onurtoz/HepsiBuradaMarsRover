using HepsiBurada.MarsRover.BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.BusinessServices.Services.RoverNavigate
{
    public interface IRoverNavigate
    {
        void Navigate(RoverPosition position);
    }
}

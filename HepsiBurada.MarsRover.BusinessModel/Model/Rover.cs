using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.BusinessModel.Model
{
    public class Rover
    {
        public Guid RoverID { get; set; }
        public RoverPosition RoverPostion { get; set; }
        public string RoverCommand { get; set; }
    }
}

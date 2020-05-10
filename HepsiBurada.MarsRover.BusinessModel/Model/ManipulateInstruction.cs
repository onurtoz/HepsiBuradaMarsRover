
using HepsiBurada.MarsRover.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.BusinessModel.Model
{
   public class ManipulateInstruction
    {
        public bool IsValid { get; set; }
        public int XstartPositon { get; set; }
        public int YstartPosition { get; set; }
        public DirectionType StartDirectionType { get; set; }
        public string RoverCommand { get; set; }
    }
}

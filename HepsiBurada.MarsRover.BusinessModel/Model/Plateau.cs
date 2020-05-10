using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.BusinessModel.Model
{
   public class Plateau
    {
        public List<int> plateauSize { get; set; }

        public Plateau()
        {
            plateauSize = new List<int>();
        }
    }
}

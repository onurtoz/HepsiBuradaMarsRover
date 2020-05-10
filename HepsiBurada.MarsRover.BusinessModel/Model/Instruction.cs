using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.BusinessModel.Model
{
   public class Instruction
    {
       
        public List<string> sendMessage { get; set; }
        public Instruction()
        {
            sendMessage = new List<string>();
        }
    }
}

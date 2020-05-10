using System;
using System.Collections.Generic;
using System.Text;
using HepsiBurada.MarsRover.BusinessModel.Model;
using HepsiBurada.MarsRover.BusinessServices.Services.Factory;
using HepsiBurada.MarsRover.BusinessServices.Services.RoverNavigate;
using HepsiBurada.MarsRover.Common.Enum;

namespace HepsiBurada.MarsRover.BusinessServices.Services.RoverService
{
    public class RoverService : IRoverService
    {

        private ManipulateInstruction _manipulateInstruction;
        private readonly Plateau _plateau;

        private readonly INavgiateFactory _navgiateFactory;

        public RoverService(INavgiateFactory navgiateFactory, Plateau plateau)
        {
            _plateau = plateau;
            _navgiateFactory = navgiateFactory;

        }
        public Rover PositionMove(Instruction instruction, Rover rover)
        {
            var manipulateInstruction = ValidateAndManipulateInstruction(instruction);
            if (manipulateInstruction.IsValid)
            {
                rover.RoverPostion.XPosition = manipulateInstruction.XstartPositon;
                rover.RoverPostion.YPosition = manipulateInstruction.YstartPosition;
                rover.RoverCommand = manipulateInstruction.RoverCommand;
                rover.RoverPostion.CurrentDirectionType = manipulateInstruction.StartDirectionType;
                var rovercharcommmand = manipulateInstruction.RoverCommand.ToCharArray();
                foreach (var rovercommand in rovercharcommmand)
                {
                    try
                    {
                        Enum.TryParse(rovercommand.ToString(), out CommandType roverCommandType);
                        _navgiateFactory.GetRoverNavigate(roverCommandType).Navigate(rover.RoverPostion);
                    }
                    catch (Exception ex)
                    {

                        return null;
                    }
                }
                bool overhead = rover.RoverPostion.XPosition > _plateau.plateauSize[0] ? true : false || rover.RoverPostion.YPosition>_plateau.plateauSize[1] ? true:false;
                return overhead == false ? rover : null;
            }
            else { return null; }


        }
        private ManipulateInstruction ValidateAndManipulateInstruction(Instruction instruction)
        {

            _manipulateInstruction = new ManipulateInstruction();
            if (instruction.sendMessage.Count == 0 || instruction.sendMessage.Count != 2 || instruction.sendMessage[0].Split(' ').Length != 3)
            {

                _manipulateInstruction.IsValid = false;
                return _manipulateInstruction;
            }
            var roverPostionLocation = instruction.sendMessage[0].Split(' ');
            var roverCommand = instruction.sendMessage[1];

            var nullcontrol = roverPostionLocation[0] == "" ? true : false || roverPostionLocation[1] == "" ? true : false || roverPostionLocation[2] == "" ? true : false;
            if (nullcontrol)
            {
                _manipulateInstruction.IsValid = false;
                return _manipulateInstruction;
            }
            int.TryParse(roverPostionLocation[0], out var roverxStartPosition);
            int.TryParse(roverPostionLocation[1], out var roveryStartPostion);
            Enum.TryParse(roverPostionLocation[2], out DirectionType roverDirection);

            if (_plateau.plateauSize.Count != 2 || _plateau.plateauSize[0] < roverxStartPosition || _plateau.plateauSize[1] < roveryStartPostion)
            {
                _manipulateInstruction.IsValid = false;
                return _manipulateInstruction;
            }
            _manipulateInstruction.IsValid = true;
            _manipulateInstruction.RoverCommand = roverCommand;
            _manipulateInstruction.StartDirectionType = roverDirection;
            _manipulateInstruction.XstartPositon = roverxStartPosition;
            _manipulateInstruction.YstartPosition = roveryStartPostion;

            return _manipulateInstruction;
        }
    }
}

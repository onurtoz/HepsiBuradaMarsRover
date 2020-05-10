using HepsiBurada.MarsRover.BusinessModel.Model;
using HepsiBurada.MarsRover.BusinessServices.Services.Factory;
using HepsiBurada.MarsRover.BusinessServices.Services.RoverService;
using HepsiBurada.MarsRover.Common.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HepsiBurada.MarsRover.UnitTest
{
    [TestClass]
    public class MarsRoverTest
    {

        private Plateau plateau;
        private RoverPosition position;
        private INavgiateFactory navgiateFactory;
        private RoverService roverService;
        private Instruction instruction;
        private Rover rover;
        [TestInitialize]
        public void Init()
        {
            plateau = new Plateau();
            position = new RoverPosition();
            navgiateFactory = new NavgiateFactory();
            instruction = new Instruction();
            rover = new Rover();
        }

        [TestMethod]
        public void NavigateTest_12N_LMLMLMLMM()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };
            roverService = new RoverService(navgiateFactory, plateau);
            instruction.sendMessage = new List<string>() { "1 2 N", "LMLMLMLMM"};
            rover.RoverID = Guid.NewGuid();
            rover.RoverPostion = position;
            rover= roverService.PositionMove(instruction, rover);
            var actualOutput = $"{rover.RoverPostion.XPosition} {rover.RoverPostion.YPosition} {rover.RoverPostion.CurrentDirectionType.ToString()}";
            var expectedOutput = "1 3 N";
            Assert.AreEqual(expectedOutput, actualOutput);
           

        }


        [TestMethod]
        public void NavigateTest_33E_MMRMMRMRRM()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };
            roverService = new RoverService(navgiateFactory, plateau);
            instruction.sendMessage = new List<string>() { "3 3 E", "MMRMMRMRRM" };
            rover.RoverID = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            var actualOutput = $"{rover.RoverPostion.XPosition} {rover.RoverPostion.YPosition} {rover.RoverPostion.CurrentDirectionType.ToString()}";
            var expectedOutput = "5 1 E";
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void NavigateTest_GreaterRoverPositionThanPlateau()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };
 
            roverService = new RoverService(navgiateFactory, plateau);
            instruction.sendMessage = new List<string>() { "6 6 E", "MMRMMRMRRM" };
            rover.RoverID = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }


        [TestMethod]
        public void NavigateTest_GreaterRoverPositionAfterPostionMoveThanPlateau()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.sendMessage = new List<string>() { "5 5 N", "MMRMMRMRRM" };
            rover.RoverID = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }




        [TestMethod]
        public void NavigateTest_InvalidCharactersofCommmand()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.sendMessage = new List<string>() { "1 2 N", "TTRMMRMRRM" };
            rover.RoverID = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }


        [TestMethod]
        public void NavigateTest_InvalidCharactersofPositionX()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.sendMessage = new List<string>() { " 2 N", "LMLMLMLMM" };
            rover.RoverID = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }


        [TestMethod]
        public void NavigateTest_InvalidCharactersofPositionY()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.sendMessage = new List<string>() { "2  N", "LMLMLMLMM" };
            rover.RoverID = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }


        [TestMethod]
        public void NavigateTest_InvalidSplitOfMessage()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.sendMessage = new List<string>() { "12N", "LMLMLMLMM" };
            rover.RoverID = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }

        [TestMethod]
        public void NavigateTest_InvalidEmptyOfMessageandCommand()
        {
            plateau.plateauSize = new List<int>() { 5, 5 };

            roverService = new RoverService(navgiateFactory, plateau);
            instruction.sendMessage = new List<string>() { "", "" };
            rover.RoverID = Guid.NewGuid();
            rover.RoverPostion = position;
            rover = roverService.PositionMove(instruction, rover);
            Assert.IsNull(rover);
        }

    }
}

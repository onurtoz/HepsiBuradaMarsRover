using HepsiBurada.MarsRover.BusinessModel.Model;
using HepsiBurada.MarsRover.BusinessServices.Services.Factory;
using HepsiBurada.MarsRover.BusinessServices.Services.RoverService;
using HepsiBurada.MarsRover.Common.Enum;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using ConsoleTables;

namespace HepsiBurada.MarsRover.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {


            var roverStartPosition = new ConsoleTable("RoverID", "RoverXPostion", "RoverYPostion", "RoverCurrentDirection");
            #region Seample

            Plateau plateau = new Plateau();
            plateau.plateauSize.Add(5);
            plateau.plateauSize.Add(5);

            List<Instruction> ınstructions = new List<Instruction>();
            Instruction rover1 = new Instruction();
            rover1.sendMessage.Add("1 2 N");
            rover1.sendMessage.Add("LMLMLMLMM");

            Instruction rover2 = new Instruction();
            rover2.sendMessage.Add("3 3 E");
            rover2.sendMessage.Add("MMRMMRMRRM");

            ınstructions.Add(rover1);
            ınstructions.Add(rover2);

            RoverPosition roverPosition = new RoverPosition();
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover()
            {

                RoverID = Guid.NewGuid(),
                RoverPostion = roverPosition,
                RoverCommand = ""
            });
            rovers.Add(new Rover()
            {

                RoverID = Guid.NewGuid(),
                RoverPostion = roverPosition,
                RoverCommand = ""
            });

            #endregion


            var serviceProvider = new ServiceCollection()
           .AddSingleton<INavgiateFactory, NavgiateFactory>()
           .AddSingleton<IRoverService, RoverService>()
           .AddSingleton<Plateau>(plateau)
         .BuildServiceProvider();

            IRoverService provider = serviceProvider.GetService<IRoverService>();

            for (int i = 0; i < rovers.Count; i++)
            {
                rovers[i] = provider.PositionMove(ınstructions[i], rovers[i]);
                if (rovers[i] != null)
                    roverStartPosition.AddRow(rovers[i].RoverID, rovers[i].RoverPostion.XPosition, rovers[i].RoverPostion.YPosition, rovers[i].RoverPostion.CurrentDirectionType);
            }

            Console.WriteLine(roverStartPosition);
            Console.ReadLine();
        }
    }
}

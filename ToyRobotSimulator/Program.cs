using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.BusinessLogic;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var surfaceCoordinateValidator = new SurfaceCoordinateValidator();
            var robot = new Robot(1, "Megatron", surfaceCoordinateValidator);
            var directionValidator = new DirectionValidator();
            var reportDisplay = new ReportConsoleDisplay();
            var paramValidator = new CommandParamValidator(surfaceCoordinateValidator, directionValidator);
            var commandManager = new CommandManager(paramValidator ,reportDisplay);
            var commandReader = new CommandConsoleReader();
            var app = new RobotAppController(robot, commandManager,commandReader,reportDisplay);
            while (true)
            {
                app.ProcessCommand();
                app.ReportRobot();
            }
           
        }
    }
}

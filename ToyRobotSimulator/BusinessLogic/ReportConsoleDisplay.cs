using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.BusinessLogic
{
    public class ReportConsoleDisplay : IReportDisplay
    {
        public void ShowRobot(Robot robot)
        {
            if (robot == null)
                return;
            if(robot.RobotPosition == null)
            {
                Console.WriteLine($@"Robot Id: {robot.Id} Name: {robot.Name} X: unknown Y: unknown Facing: unknown");

                return;
            }
            Console.WriteLine($@"Robot Id: {robot.Id} Name: {robot.Name} X: {robot.RobotPosition.Coordinate.X_Position} Y:  {robot.RobotPosition.Coordinate.Y_Position} Facing:  {robot.RobotPosition.Direction.ToString()} ");
            
        }
    }
}

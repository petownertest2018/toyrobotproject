using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Interfaces;

namespace ToyRobotSimulator.BusinessLogic
{
    public class CommandConsoleReader : ICommandReader
    {
        public string GetCommand()
        {
            Console.Write("Please give command to robot. PLACE, MOVE, etc. >> ");
            var cmd = Console.ReadLine();
            return cmd;
        }
    }
}

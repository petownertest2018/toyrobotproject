using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public interface ICommand
    {
        ICommandParam CommandParam { get; set; }
        bool GetCommandResult(RobotPosition originalPosition, out RobotPosition robotPosition);
    }
}

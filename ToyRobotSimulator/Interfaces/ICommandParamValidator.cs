using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator
{
    public interface ICommandParamValidator
    {
        ISurfaceCoordinateValidator CoordinateValidator { get; }

        ICommandParam ValidateCommand(string command);
    }
}

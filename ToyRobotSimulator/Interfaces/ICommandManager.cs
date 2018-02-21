using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Interfaces
{
    public interface ICommandManager
    {
        ICommand ChooseCommand(string rawcommand);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public interface ICommandParam
    {
        CommandType CommandParamType { get; set; }
        //Direction Direction { get; set; }
        //SurfaceCoordinate SurfaceCoordinate { get; set; }
        
    }
}

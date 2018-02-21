using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public class DirectionValidator : IDirectionValidator
    {
        public bool IsValid(string param,out Direction result)
        {
            result = Direction.UNKNOWN;
            var parsed = Enum.TryParse<Direction>(param, out result);
            if (result == Direction.UNKNOWN)
                parsed = false;

            return parsed;
        }
    }
}

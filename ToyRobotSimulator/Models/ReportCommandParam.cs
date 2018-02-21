using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Models
{
    public class ReportCommandParam : ICommandParam
    {
        private Robot _robot;

        public ReportCommandParam()
        {
        }

        public CommandType CommandParamType { get => CommandType.REPORT; set => throw new System.NotImplementedException(); }
        public Robot Robot { get => _robot; set => _robot = value; }
    }
}
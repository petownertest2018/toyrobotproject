namespace ToyRobotSimulator
{
    public class RightCommandParam : ICommandParam
    {
        private CommandType _commandType;
        public CommandType CommandParamType { get => _commandType; set => _commandType = value; }
        
    }
}
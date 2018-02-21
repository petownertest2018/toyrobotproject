using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator
{
    public class PlaceCommandParam : ICommandParam
    {
        public PlaceCommandParam(Direction direction, SurfaceCoordinate surfaceCoordinate)
        {
            Direction = direction;
            SurfaceCoordinate = surfaceCoordinate;
        }

        public CommandType CommandParamType { get => CommandType.PLACE; set => throw new System.NotImplementedException(); }
        public Direction Direction { get; set; }
        public SurfaceCoordinate SurfaceCoordinate { get; set; }

    }
}
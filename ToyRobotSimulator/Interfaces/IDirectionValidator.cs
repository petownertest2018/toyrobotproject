namespace ToyRobotSimulator
{
    public interface IDirectionValidator
    {
        bool IsValid(string param, out Direction result);
    }
}
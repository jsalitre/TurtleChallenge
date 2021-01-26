using TurtleChallenge.Domain.Entities;

namespace TurtleChallenge.Domain.Orientation
{
    public class West : CardinalDirection
    {

        public override string CardinalPointName => "W";

        public override void Move(ref Entity entity)

        {
            entity.Col--;
        }
    }
}
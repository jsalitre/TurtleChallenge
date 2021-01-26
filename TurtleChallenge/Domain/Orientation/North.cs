using TurtleChallenge.Domain.Entities;

namespace TurtleChallenge.Domain.Orientation
{
    public class North : CardinalDirection
    {

        public override string CardinalPointName => "N";

        public override void Move(ref Entity entity)

        {
            entity.Row--;
        }
    }
}
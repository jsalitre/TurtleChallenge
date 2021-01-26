using TurtleChallenge.Domain.Entities;

namespace TurtleChallenge.Domain.Orientation
{
    public class South : CardinalDirection
    {

        public override string CardinalPointName => "S";

        public override void Move(ref Entity entity)

        {
            entity.Row++;
        }
    }
}
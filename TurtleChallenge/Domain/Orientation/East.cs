
using TurtleChallenge.Domain.Entities;

namespace TurtleChallenge.Domain.Orientation
{
    public class East: CardinalDirection {

        public override string CardinalPointName => "E";

        public override void Move(ref Entity entity)
        {
            entity.Col++;
        }
    }
}
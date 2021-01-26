using TurtleChallenge.Domain.Entities;

namespace TurtleChallenge.Domain.Orientation
{
    public abstract class CardinalDirection
    {
        public abstract string CardinalPointName { get;}
        public abstract void Move(ref Entity entity);
    }
}
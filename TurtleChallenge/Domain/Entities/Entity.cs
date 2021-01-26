using TurtleChallenge.Domain.Interfaces;

namespace TurtleChallenge.Domain.Entities
{
    public class Entity : IObject
    {
        public int Row {get;set;}
        public int Col { get;set;}
    }
}
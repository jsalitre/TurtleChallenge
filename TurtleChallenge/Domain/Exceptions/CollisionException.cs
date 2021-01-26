using System;

namespace TurtleChallenge.Domain.Exceptions
{
    public class CollisionException: Exception
    {
        public CollisionException(string message):base(message)
        {
            
        }
    }
}
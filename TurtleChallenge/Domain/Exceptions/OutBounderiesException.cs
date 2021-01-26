using System;

namespace TurtleChallenge.Domain.Exceptions
{
    public class OutBounderiesException: Exception
    {
        public OutBounderiesException(string message) : base(message) { }
        
    }
}


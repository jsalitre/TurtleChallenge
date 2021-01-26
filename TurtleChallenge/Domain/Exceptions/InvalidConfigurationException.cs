using System;

namespace TurtleChallenge.Domain.Exceptions
{
   	public class InvalidConfigurationException : Exception
	{
		public InvalidConfigurationException(string message) : base(message) { }
	}
}



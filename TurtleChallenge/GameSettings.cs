using System.Collections.Generic;
using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Interfaces;

namespace TurtleChallenge
{
    public class GameSettings : IGameSettings
    {
        public Beach Beach { get;set; }
        public Turtle Turtle { get;set; }
        public ICollection<Mine> Mines { get;set; }
        public Exit Exit { get;set; }
    }
}
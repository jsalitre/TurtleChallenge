using System.Collections.Generic;
using TurtleChallenge.Domain.Entities;

namespace TurtleChallenge.Domain.Interfaces
{
    public interface IGameSettings
    {
       Beach Beach  {get;set;}
       Turtle Turtle {get;set;}
       ICollection<Mine> Mines {get;set;}

       Exit Exit {get;set;}
    }
}
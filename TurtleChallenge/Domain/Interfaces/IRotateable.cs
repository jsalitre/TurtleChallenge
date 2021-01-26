using TurtleChallenge.Domain.Orientation;

namespace TurtleChallenge.Domain.Interfaces
{
    public interface IRotateable {

        string Orientation { get; set; }
        CardinalDirection CurrentOrientation {get;set;}

        void Rotate(CardinalDirection orientation);

        void SetOrientation(CardinalDirection orientation);

        

    }

}
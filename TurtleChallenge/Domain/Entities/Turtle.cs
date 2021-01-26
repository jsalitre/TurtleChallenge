using TurtleChallenge.Domain.Interfaces;
using TurtleChallenge.Domain.Orientation;

namespace TurtleChallenge.Domain.Entities
{
    public class Turtle : Entity, IMoveable
    {
        
        public string Orientation { get; set; }

        public CardinalDirection CurrentOrientation {get;set;}

        public static Turtle Hatch(Turtle turtle, CardinalDirection orientation) {
            var newTurtle = new Turtle() { Row = turtle.Row, Col = turtle.Col};
            newTurtle.SetOrientation(orientation);
            return newTurtle;
        }

        public void Rotate(CardinalDirection orientation)
        {
            SetOrientation(orientation);
        }

        public void SetOrientation(CardinalDirection orientation)
        {
            this.CurrentOrientation = orientation;
            this.Orientation = orientation.CardinalPointName;
        }

        public void Move()
        {
            var _turle = this as Entity;
            this.CurrentOrientation.Move(ref _turle);

        }

        public override string ToString()
        {
            return $"[{this.Row}, {this.Col}] => Orientation: {this.CurrentOrientation.CardinalPointName}";
        }

        
    }
}
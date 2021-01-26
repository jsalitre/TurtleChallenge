using System.Collections.Generic;
using System.Linq;

namespace TurtleChallenge.Domain.Orientation
{
    public class Compass
    {
        private Dictionary<string, CardinalDirection> Orientations { get; set; }


        public Compass()
        {

            this.Orientations = new Dictionary<string, CardinalDirection> {
                {"N", new North()},
                {"E", new East()},
                {"S", new South()},
                {"W", new West()}
                };

        }


        public CardinalDirection GetOrientation(string cardinalPoint)
        {
            return this.Orientations[cardinalPoint];
                

        }
        
        public CardinalDirection GetNextCardinalPoint(string cardinalPoint)
        {

            CardinalDirection cardinalDirection = GetOrientation(cardinalPoint);
            var _orientationslist = this.Orientations
                    .Select(cardinalDirection => cardinalDirection.Value).ToList();

            var indexOf = cardinalDirection != null ? _orientationslist.IndexOf(cardinalDirection) : 0;

            return _orientationslist[indexOf == Orientations.Count - 1 ? 0 : indexOf + 1];
        }
    }
}
using CommandLine;

namespace TurtleChallenge.Parsers
{
    public class Options
        {

            [Option('i', "input", Default = "game-settings.json", Required = false, HelpText = "Provide game settings file")]
            public string Input { get; set; }

             [Option('m', "move", Default = "game-sequence.json", Required = false, HelpText = "Provide game movements file")]
            public string Movements { get; set; }
        }
}

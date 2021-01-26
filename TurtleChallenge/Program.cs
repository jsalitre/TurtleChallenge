using System;
using System.Collections.Generic;
using CommandLine;
using TurtleChallenge.Parsers;

namespace TurtleChallenge
{
    partial class Program
    {
        static void Main(string[] args)
        {

            // Prepare settings here

          
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(opt =>
            {
                var settings = InputParser.Parse<GameSettings>(opt.Input); 
                var moves = InputParser.Parse<Moves>(opt.Movements);

                var engine = new GameEngine(settings, moves.Sequences);
                engine.Notify += (args, e) => { Console.WriteLine(e.Message); };
                
                
                engine.Execute();

            }).WithNotParsed(HandleParseError);


        }

        static void HandleParseError(IEnumerable<Error> errors) {
                // DO NOTHING
        }
    }
}

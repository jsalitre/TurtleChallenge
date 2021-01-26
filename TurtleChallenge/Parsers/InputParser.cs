using System.IO;
using System.Text.Json;

namespace TurtleChallenge.Parsers
{
    public static class InputParser
    {
        public static T Parse<T>(string filename)
        {

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), filename.Trim());
            if (File.Exists(filepath))
            {
                var stdIn = File.ReadAllText(filepath);
                return JsonSerializer.Deserialize<T>(stdIn);
            }

            throw new FileNotFoundException("Unable to find file");
        }


        
    }
}
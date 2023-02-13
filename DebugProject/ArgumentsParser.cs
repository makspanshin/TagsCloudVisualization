using System;
using CommandLine;

namespace DebugProject
{
    public class ArgumentsParser
    {
        public static T Parse<T>(string[] args)
            where T : new()
        {
            using var parser = new Parser(config =>
            {
                config.CaseInsensitiveEnumValues = true;
                config.IgnoreUnknownArguments = true;
            });
            var parsed = parser.ParseArguments<T>(args) as Parsed<T>;
            if (parsed == null)
                Console.WriteLine("Input is incorrect");
            // Environment.Exit(-1);

            return parsed.Value;
        }
    }
}
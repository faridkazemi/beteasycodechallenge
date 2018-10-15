using System;

namespace dotnet_code_challenge.Helper
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(string msg)
        {
            Console.Error.WriteLine(msg);
        }
    }
}

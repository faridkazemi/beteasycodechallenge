namespace dotnet_code_challenge.Helper
{
    public interface ILogger
    {
        // Super simplistic logger, we could use proper log4net or Serilog
        void LogError(string msg);
    }
}

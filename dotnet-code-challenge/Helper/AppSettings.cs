namespace dotnet_code_challenge.Helper
{
    public static class AppSettings
    {
        // This should be read from the config file
        public static string SourcePath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/FeedData";
    }
}

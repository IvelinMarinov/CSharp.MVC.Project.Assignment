namespace MyMovieDb.App.Helpers
{
    public static class StringHelper
    {
        public static string GetFirstCharactersOfString(string inputStr)
        {
            return inputStr.Substring(0, 300);
        }
    }
}

using Sprache;

namespace Cygnus.Utils
{
    public static class GlobalUtils
    {
        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input[1..];
        }

        public static string AssignColor(string input)
        {
            return input switch
            {
                _ when string.Equals(input, "ok", StringComparison.OrdinalIgnoreCase) => "text-success",
                _ when string.Equals(input, "success", StringComparison.OrdinalIgnoreCase) => "text-success",
                _ => "text-danger"
            };
        }

        public static string AssignStatusColor(string input)
        {
            return input switch
            {
                _ when string.Equals(input, "live", StringComparison.OrdinalIgnoreCase) => "text-info",
                _ when string.Equals(input, "development", StringComparison.OrdinalIgnoreCase) => "text-warning",
                _ => "text-primary"
            };
        }
    }
}
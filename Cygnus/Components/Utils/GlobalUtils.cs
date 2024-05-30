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
                "OK" => "text-success",
                "success" => "text-success",
                _ => "text-danger"
            };
        }
    }
}
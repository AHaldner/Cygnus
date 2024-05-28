namespace Cygnus.Utils
{
    public static class PackageUtils
    {
        public static string GetPackageType(int packageID)
        {
            return packageID switch
            {
                1 => "Basic",
                2 => "Advanced",
                _ => "Undefined"
            };
        }
    }
}
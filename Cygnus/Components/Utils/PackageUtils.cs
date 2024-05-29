namespace Cygnus.Utils
{
    public static class PackageUtils
    {
        public static string GetPackageType(int packageID)
        {
            return packageID switch
            {
                0 => "Andromeda",
                1 => "Hydra",
                2 => "Static",
                _ => "Undefined"
            };
        }
    }
}
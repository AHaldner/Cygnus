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

        public static string FormatSize(string sizeInBytes)
        {
            string[] sizes = ["B", "KB", "MB", "GB", "TB"];
            int i = 0;
            double size = double.Parse(sizeInBytes);

            while (size >= 1024 && i < sizes.Length - 1)
            {
                size /= 1024;
                i++;
            }

            return $"{size:0.##} {sizes[i]}";
        }
    }
}
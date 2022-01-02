namespace Resources
{
    using System.Globalization;

    public sealed class SharedResource
    {
        public const string EnGb = "en-GB";

        public static string[] SupportedCultures { get; } = { EnGb };

        public static CultureInfo GetDefaultCultureInfo()
        {
            return new(EnGb);
        }

        public static CultureInfo[] GetSupportedCulturesInfo()
        {
            return SupportedCultures.Select(p => new CultureInfo(p)).ToArray();
        }
    }
}
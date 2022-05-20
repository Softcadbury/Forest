namespace Resources;

using System.Globalization;

public sealed class SharedResource
{
    public const string EnGb = "en-GB";

#pragma warning disable CA1819 // Properties should not return arrays
    public static string[] SupportedCultures { get; } = { EnGb };
#pragma warning restore CA1819 // Properties should not return arrays

    public static CultureInfo DefaultCultureInfo => new(EnGb);

    public static CultureInfo[] GetSupportedCulturesInfo()
    {
        return SupportedCultures.Select(p => new CultureInfo(p)).ToArray();
    }

    public static CultureInfo GetCurrentCulture() => Thread.CurrentThread.CurrentUICulture;

    public static string GetCurrentCultureName() => GetCurrentCulture().Name;
}
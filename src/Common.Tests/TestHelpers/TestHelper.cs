namespace Common.Tests.TestHelpers;

using AutoMapper;
using Controller.Mapping;
using NUnit.Framework;

public static class TestHelper
{
    public static string GetSolutionPath()
    {
        string sourcesFolder = $"{Path.DirectorySeparatorChar}src{Path.DirectorySeparatorChar}";
        string currentDirectoryName = TestContext.CurrentContext.TestDirectory;
        int index = currentDirectoryName.IndexOf(sourcesFolder, StringComparison.Ordinal);

        if (index == -1)
        {
            throw new InvalidOperationException($"Could not find the path {currentDirectoryName} in the solution directory");
        }

        return currentDirectoryName[..(index + sourcesFolder.Length)];
    }

    public static IMapper GetAutoMapper()
    {
        var config = new MapperConfiguration(p =>
        {
            p.AddProfile<ApplicationMapperConfiguration>();
        });

        return new Mapper(config);
    }
}
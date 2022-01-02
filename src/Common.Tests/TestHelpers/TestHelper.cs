namespace Common.Tests.TestHelpers
{
    using NUnit.Framework;

    public static class TestHelper
    {
        public static string GetSolutionPath()
        {
            string sourcesFolder = $"{Path.DirectorySeparatorChar}src{Path.DirectorySeparatorChar}";
            string currentDirectoryName = TestContext.CurrentContext.TestDirectory;
            int index = currentDirectoryName.IndexOf(sourcesFolder, StringComparison.Ordinal);

            if (index != -1)
            {
                return currentDirectoryName.Substring(0, index + sourcesFolder.Length);
            }

            throw new Exception($"Could not find the path {currentDirectoryName} in the solution directory");
        }
    }
}
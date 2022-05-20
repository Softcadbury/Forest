namespace Common.Tests.AppSettings;

using System.Reflection;
using Common.AppSettings;
using Common.Tests.TestHelpers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

public class TestAppSettings
{
    [Test]
    public void AppSettings_CheckSettingsPrecenceAndTypes()
    {
        // Arrange
        string webAppPath = Path.Combine(TestHelper.GetSolutionPath(), "Web");
        List<(string FileName, JObject FileContent)> appSettingsFiles = GetAppSettingsFiles(webAppPath).ToList();

        // Assert
        Assert.That(CheckOption<DevelopmentSettings>(appSettingsFiles, DevelopmentSettings.SectionName), Is.Empty);
    }

    private static IEnumerable<(string FileName, JObject FileContent)> GetAppSettingsFiles(string appSettingsPath)
    {
        foreach (string filePath in Directory.GetFiles(appSettingsPath, "appsettings*.json"))
        {
            string fileContent = File.ReadAllText(filePath);
            JObject fileDocument = JObject.Parse(fileContent, new JsonLoadSettings { CommentHandling = CommentHandling.Ignore });
            yield return (new FileInfo(filePath).Name, fileDocument);
        }
    }

    private static IEnumerable<string> CheckOption<T>(List<(string FileName, JObject FileContent)> appSettingsFiles, string sectionName)
    {
        PropertyInfo[] optionProperties = typeof(T).GetProperties();

        foreach ((string fileName, JObject fileContent) in appSettingsFiles)
        {
            JToken token = fileContent.GetValue(sectionName, StringComparison.InvariantCultureIgnoreCase);
            if (token == null)
            {
                continue;
            }

            foreach (JToken subToken in token)
            {
                JProperty subTokenProperty = subToken.ToObject<JProperty>();
                var optionProperty = optionProperties.SingleOrDefault(p => p.Name == subTokenProperty!.Name);

                if (optionProperty == null)
                {
                    yield return $"{sectionName}.{subTokenProperty!.Name} found in {fileName}, but not in {typeof(T).Name}";
                }
                else if (!AreTypesEqual(subToken.First, optionProperty.PropertyType))
                {
                    yield return $"{sectionName}.{subTokenProperty!.Name} of type {subToken.First!.Type} in {fileName}, but of type {optionProperty.PropertyType} in {typeof(T).Name}.cs";
                }
            }
        }
    }

    private static bool AreTypesEqual(JToken token, Type propertyType)
    {
        return token.Type switch
        {
            JTokenType.Integer => propertyType == typeof(int),
            JTokenType.Float => propertyType == typeof(float),
            JTokenType.String => propertyType == typeof(string) || propertyType == typeof(Guid) || AreUriTypesEqual(token, propertyType),
            JTokenType.Boolean => propertyType == typeof(bool),
            _ => true,
        };
    }

    private static bool AreUriTypesEqual(JToken token, Type propertyType)
    {
        bool isValidUri = Uri.IsWellFormedUriString(token.Value<string>(), UriKind.Absolute);
        return propertyType == typeof(Uri) && isValidUri;
    }
}
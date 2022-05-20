namespace Controller.Tests.Api
{
    using Common.Tests.Base;
    using NUnit.Framework;

    [TestFixture]
    public class IntegrationTestTreeController : ServerIntegrationTestBase
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public async Task TestTree()
        {
            await Login();
            var response = await Client.GetStringAsync("/api/trees/a8fdad2e-ccf9-4cd2-b0b3-e9965548c7db/nodes/prettyPrint");
        }
    }
}
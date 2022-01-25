namespace Controller.Tests.Mapping
{
    using AutoMapper;
    using Controller.Mapping;
    using NUnit.Framework;

    [TestFixture]
    public class TesApplicationMapperConfiguration
    {
        [Test]
        public void ApplicationMapperConfiguration_TestConfigurationValidity()
        {
            var config = new MapperConfiguration(p =>
            {
                p.AddProfile<ApplicationMapperConfiguration>();
            });

            config.AssertConfigurationIsValid();
        }
    }
}
namespace Common.Tests.TestHelpers
{
    using Microsoft.AspNetCore.Mvc;
    using NUnit.Framework;

    public static class TestExtensions
    {
        public static T GetOkContent<T>(this ActionResult<T> actionResult)
        {
            Assert.That(actionResult.Result, Is.InstanceOf<OkObjectResult>());
            var okObjectResult = (OkObjectResult)actionResult.Result!;
            return (T)okObjectResult.Value!;
        }
    }
}
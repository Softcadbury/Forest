namespace Controller.Api
{
    using System.Collections.Concurrent;
    using Controller.Base;
    using Controller.ViewModels.Resources;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;
    using Resources;

    [Route("api/resources")]
    public class ResourcesController : CustomApiControllerBase
    {
        private static readonly ConcurrentDictionary<string, ResourcesViewModel> CachedResources = new();
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ResourcesController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet("")]
        public ActionResult<ResourcesViewModel> Get()
        {
            if (!CachedResources.TryGetValue(SharedResource.GetCurrentCultureName(), out ResourcesViewModel? resources))
            {
                resources = new ResourcesViewModel(_localizer);
                CachedResources.TryAdd(SharedResource.GetCurrentCultureName(), resources);
            }

            return Ok(resources);
        }
    }
}
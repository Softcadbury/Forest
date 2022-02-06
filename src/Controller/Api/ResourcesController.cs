namespace Controller.Api
{
    using Controller.Base;
    using Controller.ViewModels.Resources;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;
    using Resources;

    [Route("api/resources")]
    public class ResourcesController : CustomApiControllerBase
    {
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ResourcesController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet("")]
        public ActionResult<ResourcesViewModel> Get()
        {
            return Ok(new ResourcesViewModel(_localizer));
        }
    }
}
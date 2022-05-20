namespace Controller.Controllers;

using Controller.Base;
using Microsoft.AspNetCore.Mvc;

[Route("error")]
public class ErrorController : CustomControllerBase
{
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
}
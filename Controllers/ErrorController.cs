using Microsoft.AspNetCore.Mvc;

namespace XotaApi.Controllers;

[Route("error/[controller]")]
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{

    [Route("/error")]
    public IActionResult HandleError() => Problem();
}
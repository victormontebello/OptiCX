using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    public BaseController() => Ok("Healthy");
    
    [HttpGet]
    public OkObjectResult HealthCheck() => Ok("Healthy");

}
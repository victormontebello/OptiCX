using Infraestructure.Rds;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    private readonly RdsDbContext _context;
    public BaseController(RdsDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public OkObjectResult HealthCheck() => Ok("Healthy");

}
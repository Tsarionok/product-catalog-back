using Microsoft.AspNetCore.Mvc;

namespace ProductCatalog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ILogger<CurrencyController> _logger;

    public CurrencyController(ILogger<CurrencyController> logger)
    {
        _logger = logger;
    }
}
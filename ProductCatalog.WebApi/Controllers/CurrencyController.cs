using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BusinessLogic.DataTransferObjects;
using ProductCatalog.BusinessLogic.Services;
using ProductCatalog.WebApi.ApiModels;

namespace ProductCatalog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ILogger<CurrencyController> _logger;
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;

    public CurrencyController(ILogger<CurrencyController> logger, ICurrencyService currencyService, IMapper mapper)
    {
        _logger = logger;
        _currencyService = currencyService;
        _mapper = mapper;
    }

    [HttpGet("{id:long}")]
    public async Task<CurrencyApiModel> GetByIdAsync(long id)
    {
        var currencyResult = await _currencyService.GetByIdAsync(id);
        return _mapper.Map<CurrencyApiModel>(currencyResult);
    }

    [HttpGet("code/{code}")]
    public async Task<CurrencyApiModel> GetByCodeAsync(string code)
    {
        var currencyResult = await _currencyService.GetByCodeAsync(code);
        return _mapper.Map<CurrencyApiModel>(currencyResult);
    }

    [HttpGet]
    public async Task<IEnumerable<CurrencyApiModel>> GetAllAsync()
    {
        var currenciesResult = await _currencyService.GetAllAsync();
        return _mapper.Map<IEnumerable<CurrencyApiModel>>(currenciesResult);
    }

    [HttpPost]
    public async Task<CurrencyApiModel> AddAsync(AddCurrencyApiModel currency)
    {
        var currencyResult = await _currencyService.AddAsync(
                _mapper.Map<CurrencyDto>(currency)
            );
        return _mapper.Map<CurrencyApiModel>(currencyResult);
    }
}
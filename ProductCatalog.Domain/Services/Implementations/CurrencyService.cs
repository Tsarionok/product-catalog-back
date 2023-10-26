using AutoMapper;
using ProductCatalog.Storage.Entities;
using ProductCatalog.Storage.Repository;
using ProductCatalog.Domain.DataTransferObjects;

namespace ProductCatalog.Domain.Services.Implementations;

public class CurrencyService : ICurrencyService
{
    private ICurrencyRepository _currencyRepository;
    private IMapper _mapper;

    public CurrencyService(ICurrencyRepository currencyRepository, IMapper mapper)
    {
        _currencyRepository = currencyRepository;
        _mapper = mapper;
    }

    public async Task<CurrencyDto> GetByIdAsync(long id) =>
        _mapper.Map<CurrencyDto>(await _currencyRepository.GetByIdAsync(id));

    public async Task<CurrencyDto> GetByCodeAsync(string code) =>
        _mapper.Map<CurrencyDto>(await _currencyRepository.GetByCodeAsync(code));

    public async Task<IEnumerable<CurrencyDto>> GetAllAsync() =>
        _mapper.Map<IEnumerable<CurrencyDto>>(await _currencyRepository.GetAllAsync());

    public async Task<CurrencyDto> AddAsync(CurrencyDto currency) =>
        _mapper.Map<CurrencyDto>(await _currencyRepository.AddAsync(_mapper.Map<Currency>(currency)));

    public async Task<CurrencyDto> UpdateAsync(CurrencyDto currency) =>
        _mapper.Map<CurrencyDto>(await _currencyRepository.UpdateAsync(_mapper.Map<Currency>(currency)));

    public async Task<CurrencyDto> DeleteByIdAsync(long id) =>
        _mapper.Map<CurrencyDto>(await _currencyRepository.DeleteByIdAsync(id));

    public async Task<CurrencyDto> DeleteByCodeAsync(string code) =>
        _mapper.Map<CurrencyDto>(await _currencyRepository.DeleteByCodeAsync(code));
}
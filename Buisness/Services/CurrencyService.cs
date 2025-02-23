using Buisness.Factories;
using Buisness.Models.Dtos.CreateForm;
using Buisness.Models.Dtos.UpdateForm;
using Buisness.Models;
using DatabaseAssignment.Interfaces;
using DatabaseAssignment.Repositories;
using Buisness.Models.Dtos;

namespace Buisness.Services;

public class CurrencyService(ICurrencyRepository currencyRepository)
{
    private readonly ICurrencyRepository _currencyRepository = currencyRepository;
    public async Task<bool> CreateNewcurrencyAsync(CurrencyCreateForm form)
    {
        if (!await _currencyRepository.ExistsAsync(x => x.CurrencyCode == form.CurrencyCode))
        {
            var entity = CurrencyFactory.Create(form);
            entity = await _currencyRepository.AddAsync(entity);
            if (entity != null && entity.CurrencyCode == form.CurrencyCode)
                return true;
        }
        return false;
    }

    public async Task<IEnumerable<Currency>> Getcurrencyes()
    {
        var entities = await _currencyRepository.GetAsync();
        return entities.Select(CurrencyFactory.Create);
    }

    public async Task<Currency> GetActivityAsync(string CurrencyCode)
    {
        var entity = await _currencyRepository.GetAsync(x => x.CurrencyCode == CurrencyCode);
        return entity != null ? CurrencyFactory.Create(entity) : null!;
    }

    public async Task<bool> UpdatecurrencyAsync(CurrencyUpdateForm form)
    {
        var entity = await _currencyRepository.GetAsync(x => x.CurrencyCode == form.CurrencyCode);

        if (entity != null)
        {
            entity = CurrencyFactory.Update(form);
            entity = await _currencyRepository.AddAsync(entity);
            if (entity != null && entity.CurrencyCode == form.CurrencyCode)
                return true;
        }
        return false;
    }

    public async Task<bool> DeleteCurrencyAsync(string currencyCode)
    {
        var entity = await _currencyRepository.GetAsync(x => x.CurrencyCode == currencyCode);

        if (entity != null)
        {
            var result = await _currencyRepository.RemoveAsync(entity);
            return result;
        }
        return false;
    }
}

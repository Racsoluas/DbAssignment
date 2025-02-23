using Buisness.Models.Dtos;
using Buisness.Models.Dtos.CreateForm;
using Buisness.Models.Dtos.UpdateForm;
using DatabaseAssignment.Entities;

namespace Buisness.Factories;

public static class CurrencyFactory
{
    public static CurrencyEntity Create(CurrencyCreateForm form) => new()
    {
        CurrencyCode = form.CurrencyCode,
        Currency = form.Currency,
        CurrencySymbol = form.CurrencySymbol
    };

    public static CurrencyEntity Update(CurrencyUpdateForm form) => new()
    {
        CurrencyCode = form.CurrencyCode,
        Currency = form.Currency,
        CurrencySymbol = form.CurrencySymbol
    };

    public static Currency Create(CurrencyEntity entity) => new()
    {
        CurrencyCode = entity.CurrencyCode,
        CurrencyName = entity.Currency,
        CurrencySymbol = entity.CurrencySymbol
    };
}

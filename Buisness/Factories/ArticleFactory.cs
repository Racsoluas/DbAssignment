using Buisness.Models.Dtos;
using Buisness.Models.Dtos.CreateForm;
using Buisness.Models.Dtos.UpdateForm;
using DatabaseAssignment.Entities;

namespace Buisness.Factories;

public static class ArticleFactory
{
    public static ArticleEntity Create(ArticleCreateForm form) => new()
    {
        EAN = form.EAN,
        ArticleName = form.ArticleName,
        Description = form.Description,
        Price = form.Price,
        CurrencyId = form.CurrencyId,
    };

    public static ArticleEntity Update(ArticleUpdateForm form) => new()
    {
        Id = form.Id,
        EAN = form.EAN,
        ArticleName = form.ArticleName,
        Description = form.Description,
        Price = form.Price,
        CurrencyId = form.CurrencyId,
    };

    public static Article Create(ArticleEntity entity) => new()
    {
        Id = entity.Id,
        EAN = entity.EAN,
        ArticleName = entity.ArticleName,
        Description = entity.Description,
        Price = entity.Price,
        Currency = new()
        {
            CurrencyCode = entity.Currency.CurrencyCode,
            CurrencyName = entity.Currency.Currency,
            CurrencySymbol = entity.Currency.CurrencySymbol
        }
    };
}

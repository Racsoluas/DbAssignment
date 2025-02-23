using Buisness.Models.Dtos.CreateForm;
using Buisness.Models.Dtos.UpdateForm;
using Buisness.Models.Dtos;
using DatabaseAssignment.Entities;
using DatabaseAssignment.Interfaces;

namespace Buisness.Services;

public class ArticleService(IArticleRepository articleRepository)
{
    public IArticleRepository ArticleRepository { get; } = articleRepository;

    public static class ArticleFactory
    {
        public static ArticleEntity Create(ArticleCreateForm form)
        {
            return new()
            {
                ArticleName = form.ArticleName,
                Description = form.Description,
                Price = form.Price,
                CurrencyId = form.CurrencyId,
            };
        }

        public static ArticleEntity Update(ArticleUpdateForm form) => new()
        {
            Id = form.Id,
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
}

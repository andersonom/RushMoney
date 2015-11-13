using RushMoney.Application.Interfaces;
using RushMoney.Domain.Entities;
using RushMoney.Domain.Interfaces.Services;

namespace RushMoney.Application
{
    public class CategoryAppService : AppServiceBase<Category>, ICategoryAppService
    {
        private readonly ICategoryService _CategoryService;

        public CategoryAppService(ICategoryService CategoryService) : base (CategoryService)
        {
            _CategoryService = CategoryService;
        }        
    }
}

using RushMoney.Domain.Entities;
using RushMoney.Domain.Interfaces.Repositories;
using RushMoney.Domain.Interfaces.Services;

namespace RushMoney.Domain.Services
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryService(ICategoryRepository CategoryRepository) : base(CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }
    }
}

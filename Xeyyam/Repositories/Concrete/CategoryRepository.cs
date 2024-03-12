using Xeyyam.DAL;
using Xeyyam.Models;
using Xeyyam.Repositories.Abstract;
using Xeyyam.Repositories.Concrete.Generic;

namespace Xeyyam.Repositories.Concrete;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}

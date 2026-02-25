using Mission08_Team0313.Models;

namespace Mission08_Team0313.Data;

public class CategoryRepository : ICategoryRepository
{
    private readonly TaskContext _context;

    public CategoryRepository(TaskContext context)
    {
        _context = context;
    }

    public IQueryable<Category> GetCategories()
    {
        return _context.Categories.OrderBy(c => c.CategoryName);
    }
}

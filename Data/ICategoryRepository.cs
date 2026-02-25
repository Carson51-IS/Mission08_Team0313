using Mission08_Team0313.Models;

namespace Mission08_Team0313.Data;

public interface ICategoryRepository
{
    IQueryable<Category> GetCategories();
}

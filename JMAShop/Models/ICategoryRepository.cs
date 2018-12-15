using System.Collections.Generic;

namespace JMAShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

    }
}

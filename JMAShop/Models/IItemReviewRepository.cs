using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMAShop.Models
{
    public interface IItemReviewRepository
    {
        void AddItemReview(ItemReview itemReview);
        IEnumerable<ItemReview> GetReviewsForItem(int pieId);
    }
}

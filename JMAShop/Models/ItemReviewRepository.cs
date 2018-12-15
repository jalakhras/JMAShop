using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMAShop.Models
{
    public class ItemReviewRepository : IItemReviewRepository
    {
        private readonly AppDbContext _appDbContext;

        public ItemReviewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddItemReview(ItemReview itemReview)
        {
            _appDbContext.ItemReviews.Add(itemReview);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<ItemReview> GetReviewsForItem(int itemId)
        {
            return _appDbContext.ItemReviews.Where(p => p.Item.ItemId == itemId);
        }
    }
}

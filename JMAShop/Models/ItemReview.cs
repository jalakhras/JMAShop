namespace JMAShop.Models
{
    public class ItemReview
    {
        public int ItemReviewId { get; set; }
        public Item Item { get; set; }
        public string Review { get; set; }
    }
}

namespace Core.Model
{
    public class BasketItem : AbsBase
    {
        public string BucketId { get; set; }
        public string ProductId { get; set; }
        public int Qty { get; set; }
    }
}

namespace Core.ViewModel
{
    public class BasketSummaryViewModel
    {
        public decimal TotalPrice { get; set; }
        public int TotalQty { get; set; }

        public BasketSummaryViewModel(decimal totalPrice, int totalQty)
        {
            TotalPrice = totalPrice;
            TotalQty = totalQty;
        }
        public BasketSummaryViewModel()
        {
        }
    }
}

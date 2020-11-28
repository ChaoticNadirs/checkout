namespace Checkout
{
    public class MultiItemValueDiscount : MultiItemDiscount
    {
        private readonly decimal _discountedPrice;

        public MultiItemValueDiscount(string sku, int numItemsNeededForDiscount, decimal discountedPrice) 
            : base(sku, numItemsNeededForDiscount)
        {
            _discountedPrice = discountedPrice;
        }

        protected override decimal CalculateGroupDiscount(decimal groupPrice)
        {
            return groupPrice - _discountedPrice;
        }
    }
}

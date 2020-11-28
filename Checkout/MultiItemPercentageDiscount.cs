namespace Checkout
{
    public class MultiItemPercentageDiscount : MultiItemDiscount
    {
        private readonly decimal _discountPercentage;

        public MultiItemPercentageDiscount(string sku, int numItemsNeededForDiscount, decimal discountPercentage) 
            : base(sku, numItemsNeededForDiscount)
        {
            _discountPercentage = discountPercentage;
        }

        protected override decimal CalculateGroupDiscount(decimal groupPrice)
        {
            return groupPrice * _discountPercentage / 100m;
        }
    }
}

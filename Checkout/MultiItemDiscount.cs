using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public abstract class MultiItemDiscount
    {
        private readonly string _sku;
        private readonly int _numItemsNeededForDiscount;

        public MultiItemDiscount(string sku, int numItemsNeededForDiscount)
        {
            _sku = sku;
            _numItemsNeededForDiscount = numItemsNeededForDiscount;
        }

        public decimal GetDiscount(IEnumerable<Item> items)
        {
            var skuItems = items.Where(x => x.Sku == _sku);
            var skuItemsCount = skuItems.Count();
            if (skuItemsCount == 0)
            {
                return 0;
            }

            var numDiscountGroups = skuItems.Count() / _numItemsNeededForDiscount;
            var unitPrice = skuItems.First().Price;

            var groupPrice = _numItemsNeededForDiscount * unitPrice;
            var groupDiscount = CalculateGroupDiscount(groupPrice);

            var discount = groupDiscount * numDiscountGroups;

            return discount;
        }

        protected abstract decimal CalculateGroupDiscount(decimal groupPrice);
    }
}

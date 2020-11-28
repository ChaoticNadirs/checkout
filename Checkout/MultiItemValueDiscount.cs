using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class MultiItemValueDiscount : IMultiItemDiscount
    {
        private readonly string _sku;
        private readonly int _numItemsNeededForDiscount;
        private readonly decimal _discountedPrice;

        public MultiItemValueDiscount(string sku, int numItemsNeededForDiscount, decimal discountedPrice)
        {
            _sku = sku;
            _numItemsNeededForDiscount = numItemsNeededForDiscount;
            _discountedPrice = discountedPrice;
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
            var groupDiscount = groupPrice - _discountedPrice;

            var discount = groupDiscount * numDiscountGroups;

            return discount;
        }
    }
}

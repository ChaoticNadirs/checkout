using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Basket
    {
        private readonly ICollection<Item> _items;
        private readonly IMultiItemDiscount _discount;

        public Basket(IMultiItemDiscount discount)
        {
            _items = new List<Item>();
            _discount = discount;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public decimal GetTotal()
        {
            var total = _items.Sum(x => x.Price);
            total -= _discount.GetDiscount(_items);
            return total;
        }
    }
}

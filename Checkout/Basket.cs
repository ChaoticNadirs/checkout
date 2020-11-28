using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Basket
    {
        private readonly ICollection<Item> _items;
        private readonly IEnumerable<MultiItemDiscount> _discounts;

        public Basket(IEnumerable<MultiItemDiscount> discounts)
        {
            _items = new List<Item>();
            _discounts = discounts;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public decimal GetTotal()
        {
            var total = _items.Sum(x => x.Price);

            foreach (var discount in _discounts)
            {
                total -= discount.GetDiscount(_items);
            }
            
            return total;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Basket
    {
        private readonly ICollection<Item> _items;

        public Basket()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public decimal GetTotal()
        {
            return _items.Sum(x => x.Price);
        }
    }
}

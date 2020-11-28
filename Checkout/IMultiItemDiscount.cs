using System.Collections.Generic;

namespace Checkout
{
    public interface IMultiItemDiscount
    {
        decimal GetDiscount(IEnumerable<Item> items);
    }
}

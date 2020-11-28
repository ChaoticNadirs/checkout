using FluentAssertions;
using Xunit;

namespace Checkout.Tests
{
    public class BasketTests
    {
        private readonly Basket _basket;
        private readonly decimal _itemAPrice = 10m;
        private readonly decimal _itemBPrice = 15m;
        private readonly decimal _itemCPrice = 40m;

        public BasketTests()
        {
            var discount = new MultiItemValueDiscount("B", 3, 40m);
            _basket = new Basket(discount);
        }

        [Fact]
        public void ShouldTotal0WhenTheBasketIsEmpty()
        {
            // When
            var total = _basket.GetTotal();

            // Then
            total.Should().Be(0);
        }

        [Theory]
        [InlineData(1, 10)]
        [InlineData(2, 20)]
        public void ShouldPriceItemACorrectly(int count, decimal expectedTotal)
        {
            // Given
            AddItemsToBasket("A", _itemAPrice, count);

            // When
            var total = _basket.GetTotal();

            // Then
            total.Should().Be(expectedTotal);
        }

        [Theory]
        [InlineData(1, 15)]
        [InlineData(2, 30)]
        [InlineData(3, 40)]
        [InlineData(4, 55)]
        [InlineData(5, 70)]
        [InlineData(6, 80)]
        public void ShouldApplyAThreeForFortyDiscountToItemB(int count, decimal expectedTotal)
        {
            // Given
            AddItemsToBasket("B", _itemBPrice, count);

            // When
            var total = _basket.GetTotal();

            // Then
            total.Should().Be(expectedTotal);
        }

        [Theory]
        [InlineData(1, 40)]
        [InlineData(2, 80)]
        public void ShouldPriceItemCCorrectly(int count, decimal expectedTotal)
        {
            // Given
            AddItemsToBasket("C", _itemCPrice, count);

            // When
            var total = _basket.GetTotal();

            // Then
            total.Should().Be(expectedTotal);
        }

        [Fact]
        public void ShouldPriceAMixedBasketOfGoodsCorrectly()
        {
            // Given
            AddItemsToBasket("A", _itemAPrice, 1);
            AddItemsToBasket("B", _itemBPrice, 3);
            AddItemsToBasket("C", _itemCPrice, 1);

            // When
            var total = _basket.GetTotal();

            // Then
            total.Should().Be(90m);
        }

        private void AddItemsToBasket(string sku, decimal price, int count)
        {
            for (int i = 0; i < count; i++)
            {
                _basket.AddItem(new Item { Sku = sku, Price = price });
            }
        }
    }
}

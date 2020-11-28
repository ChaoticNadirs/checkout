using FluentAssertions;
using Xunit;

namespace Checkout.Tests
{
    public class BasketTests
    {
        private readonly Basket _basket;

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
            AddItemsToBasket("A", 10m, count);

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
            AddItemsToBasket("B", 15m, count);

            // When
            var total = _basket.GetTotal();

            // Then
            total.Should().Be(expectedTotal);
        }

        [Fact]
        public void ShouldPriceAMixedBasketOfGoodsCorrectly()
        {
            // Given
            AddItemsToBasket("A", 10m, 1);
            AddItemsToBasket("B", 15m, 3);

            // When
            var total = _basket.GetTotal();

            // Then
            total.Should().Be(50m);
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

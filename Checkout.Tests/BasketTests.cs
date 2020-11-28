using FluentAssertions;
using Xunit;

namespace Checkout.Tests
{
    public class BasketTests
    {
        private readonly Basket _basket;

        public BasketTests()
        {
            _basket = new Basket();
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
            for (int i = 0; i < count; i++)
            {
                _basket.AddItem(new Item { Sku = "A", Price = 10m });
            }

            // When
            var total = _basket.GetTotal();

            // Then
            total.Should().Be(expectedTotal);
        }
    }
}

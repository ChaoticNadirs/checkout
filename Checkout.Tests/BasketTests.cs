using FluentAssertions;
using Xunit;

namespace Checkout.Tests
{
    public class BasketTests
    {
        [Fact]
        public void ShouldTotal0WhenTheBasketIsEmpty()
        {
            // Given
            var basket = new Basket();

            // When
            var total = basket.GetTotal();

            // Then
            total.Should().Be(0);
        }
    }
}

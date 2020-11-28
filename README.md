# Checkout Kata

## Requirements
Implement a solution for a checkout kata that follows the requirements below.

* Given I have selected to add an item to the basket Then the item should be added to the basket
* Given items have been added to the basket Then the total cost of the basket should be calculated
* Given I have added a multiple of 3 lots of item ‘B’ to the basket Then a promotion of ‘3 for 40’ should be applied to every multiple of 3 (see: Grid 1).
* Given I have added a multiple of 2 lots of item ‘D’ to the basket Then a promotion of ‘25% off’ should be applied to every multiple of 2 (see: Grid 1).

| Item SKU | Unit Price | Promotion       |
|----------|------------|-----------------|
| A        | 10         |                 |
| B        | 15         | 3 for 40        |
| C        | 40         |                 |
| D        | 55         | 25% off every 2 |

## Solution

### Checkout.Tests
Unit tests are provided in xUnit, with FluentAssertions to provide clean, readable assertion syntax. Theories with inline data are used to reduce duplication of code.

### Checkout
The main checkout functionality is provided as a .net core class library. This could be added to a web app for a full user facing implementation. 

The project follows SOLID principles with single responsibilty classes that are open for extension and closed for modification.

* Item.cs is a simple POCO class to hold properties for each product.
* Basket.cs manages the contents of the shopping basket. The basket is open for extension as the various discounts are injected into the constructor. Additional discount strategies could be added without modifying the basket code.
* MultiItemDiscount.cs is an abstract base class which contains common code for the various concrete multi item discounts set out in the requirements. This keeps the concrete classes DRY.
* MultiItemPercentageDiscount.cs is a concrete implementation of the 25% off every 2 items discount. The implementation is quite generic and could easily by extended to x% off every n items by passing the appropriate values to the constructor.
* MultiItemValueDiscount.cs is a concrete implementation of the 3 for 40 discount. The implementation is quite generic and could easily by extended to £x off every n items by passing the appropriate values to the constructor.

# Use a Scenario Outline
Often we will have the same scenario logic but with different data values.
We could write additional scenarios but this gets tedious and more
importantly violates DRY.

Instead, we can use a `Scenario Outline` and create an `Examples` table
with the data values.

Get the `Add two numbers (using a scenario outline)` scenario working then
remove the `@wip` tag.

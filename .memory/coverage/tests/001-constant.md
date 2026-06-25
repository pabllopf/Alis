# Test Record: Constant.cs

## File Tested
6_Ideation/Math/src/Util/Constant.cs

## Test File
6_Ideation/Math/test/ConstantTest.cs

## Tests Added
10 [Fact] tests, one per constant field:
- Epsilon_ReturnsExpectedValue
- Euler_ReturnsExpectedValue
- E_ReturnsExpectedValue
- Log10E_ReturnsExpectedValue
- Log2E_ReturnsExpectedValue
- Pi_ReturnsExpectedValue
- PiOver2_ReturnsExpectedValue
- PiOver4_ReturnsExpectedValue
- TwoPi_ReturnsExpectedValue
- Tau_ReturnsExpectedValue

## Commit
d4fc8b6f7

## Pattern
For public const fields: assert the field equals its documented expected value or its calculated equivalent.

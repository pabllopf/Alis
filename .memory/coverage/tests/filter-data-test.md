## Test File

4_Operation/Physic/test/Common/Logic/FilterDataTest.cs

## Test Class

Alis.Core.Physic.Test.Common.Logic.FilterDataTest

## Tests

Total: 24 (17 existing + 7 new)

### New Tests

| Test | What it covers |
|------|---------------|
| IsActiveOn_ShouldReturnFalse_WhenDisabledGroupMatches | IsDisabledOnGroup returns true → IsActiveOn returns false |
| IsActiveOn_ShouldReturnFalse_WhenDisabledCategoryMatches | IsDisabledOnCategory returns true → IsActiveOn returns false |
| IsActiveOn_ShouldReturnTrue_WhenEnabledGroupMatches | IsEnabledOnGroup returns true → IsActiveOn returns true |
| IsActiveOn_ShouldReturnTrue_WhenEnabledCategoryMatches | IsEnabledOnCategory returns true → IsActiveOn returns true |
| IsActiveOn_ShouldReturnFalse_WhenBodyHasNoFixtures | Empty fixture list → loop skips → return false |
| IsActiveOn_ShouldReturnFalse_WhenEnabledFilterHasNoMatch | HasEnabledFilter true but no match → loop ends → return false |
| IsInEnabledInCategory_ShouldReturnFalse_ForNotEnabledCategory | IsInEnabledInCategory false case |

## Framework

xUnit, net8.0

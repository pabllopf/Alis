---
status: Done
---

## Test File

4_Operation/Physic/test/Dynamics/Contacts/ContactTest.cs

## Test Class

Alis.Core.Physic.Test.Dynamics.Contacts.ContactTest

## Tests

Total: 22 (1 existing + 21 new)

### New Tests

| Test | What it covers |
|------|---------------|
| Constructor_WithNullFixtures_ShouldSetDefaults | Reset() null branch: default property values |
| Constructor_WithValidFixtures_ShouldInitializeProperties | Reset() non-null branch: FixtureA/B, ChildIndexA/B set |
| Friction_DefaultValue_ShouldBeZero | Default Friction value |
| Friction_SetAndGet_ShouldRoundtrip | Friction get/set |
| Restitution_DefaultValue_ShouldBeZero | Default Restitution value |
| Restitution_SetAndGet_ShouldRoundtrip | Restitution get/set |
| TangentSpeed_DefaultValue_ShouldBeZero | Default TangentSpeed value |
| TangentSpeed_SetAndGet_ShouldRoundtrip | TangentSpeed get/set |
| Enabled_DefaultValue_ShouldBeTrue | Default Enabled = true |
| Enabled_SetAndGet_ShouldRoundtrip | Enabled get/set roundtrip |
| IsTouching_DefaultValue_ShouldBeFalse | Default IsTouching = false |
| IsTouching_SetAndGet_ShouldRoundtrip | IsTouching get/set |
| Next_DefaultValue_ShouldBeNull | Default Next = null |
| Next_SetAndGet_ShouldRoundtrip | Next get/set |
| Prev_DefaultValue_ShouldBeNull | Default Prev = null |
| Prev_SetAndGet_ShouldRoundtrip | Prev get/set |
| ResetFriction_WithValidFixtures_ShouldMixFrictions | ResetFriction delegates to SettingEnv.MixFriction |
| ResetRestitution_WithValidFixtures_ShouldMixRestitutions | ResetRestitution delegates to SettingEnv.MixRestitution |
| Create_WithCircleShapes_ShouldReturnContact | Contact.Create factory with empty pool, Circle+Circle |
| Create_WithPolygonAndCircle_ShouldNotSwap | Contact.Create keeps order for Polygon+Circle |
| Destroy_WithoutManifoldPoints_ShouldNotThrow | Destroy early return (no manifold points) |

## Framework

xUnit, net8.0

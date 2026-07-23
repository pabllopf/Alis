# Issue: AZ-BlpcYiLjI1diOPXKO

- Rule: csharpsquid:S1905
- File: 2_Application/Alis/src/Core/Ecs/Systems/Manager/Scene/SceneManager.cs
- Line: 83
- Severity: MINOR
- Message: Remove this unnecessary cast to 'List<Ecs.Scene>'.
- Status: RESOLVED

## Resolution

Removed unnecessary cast `(List<Ecs.Scene>)value` from the property setter, since `value` is already `List<Ecs.Scene>`.

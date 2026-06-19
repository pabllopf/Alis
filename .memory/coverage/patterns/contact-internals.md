## Pattern: Testing Internal/ProtectedInternal Types via InternalsVisibleTo

### When to Use

When a type has `protected internal` constructor or `internal` methods, and the `.csproj` has `<InternalsVisibleTo Include="$(AssemblyName).Test"/>` (most projects in this solution do).

### Test Template

```csharp
// Create instances with null fixtures for property-only tests
Contact contact = new Contact(null, 0, null, 0);

// Create with valid fixtures for method behavior tests
Fixture fixtureA = new Fixture(new CircleShape(0.5f, 1.0f));
fixtureA.GetFriction = 0.5f;
Fixture fixtureB = new Fixture(new CircleShape(0.5f, 1.0f));
Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
contact.ResetFriction();

// Access internal factory methods via InternalsVisibleTo
DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
ContactManager contactManager = new ContactManager(broadPhase);
Contact contact = Contact.Create(contactManager, fixtureA, 0, fixtureB, 0);
```

### Key Dependencies

- `Alis.Core.Physic.Dynamics.Contacts.Contact`
- `Alis.Core.Physic.Dynamics.Fixture`
- `Alis.Core.Physic.Collisions.Shapes.CircleShape`
- `Alis.Core.Physic.Collisions.DynamicTreeBroadPhase`
- `Alis.Core.Physic.Dynamics.ContactManager`
- `.csproj` must have `<InternalsVisibleTo Include="$(AssemblyName).Test"/>`

### Learned

- `new Fixture(Shape)` creates a standalone Fixture without a Body (valid for property testing)
- `ContactManager` constructor requires `IBroadPhase` — use `DynamicTreeBroadPhase()`
- Contact constructor: `new Contact(fixtureA, indexA, fixtureB, indexB)` (protected internal, accessible via InternalsVisibleTo)
- `Contact.Destroy()` is internal — accessible via InternalsVisibleTo
- Standalone Fixtures have `GetBody == null`, which is safe for read-only property access

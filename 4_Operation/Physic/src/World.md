# World Class

```
Genera todos los casos de uso y casos de pruebas del siguiente método cumpliendo los siguientes requisitos:
1. En ingles.
2. En formato markdown.
4. Los casos de uso deben incluir los siguientes apartados: Preconditions, Flow of Events y Postconditions.
5. Los casos de pruebas deben incluir los siguientes apartados: Test Data, Test Steps , Expected Results y Unit Test (programado en c# utilizando xunit y moq)

/// <summary>
/// Clears the forces
/// </summary>
internal void ClearForces() => Bodies.ForEach(i => i.ClearForces());
```


## Creating a World

First, we define the gravity vector.

```csharp
    Vector2F gravity = new Vector2F(x: 0.0f, y: 9.8f);
```

Now we create the world object.

```csharp
    World myWorld = new World(gravity: gravity);
```

---------

# Method ClearForces()


```csharp
/// <summary>
/// Clear all forces
/// </summary>
internal void ClearForces() => Bodies.ForEach(i => i.ClearForces());
```

Use Cases
---------

### Use Case 1: Clear all forces

**Preconditions:**

*   There must be at least one body in the list of bodies.

**Flow of Events:**

1.  The user calls the ```ClearForces``` method.
2.  The method iterates through each body in the list of bodies.
3.  For each body, the method calls the ```ClearForces``` method on that body.

**Postconditions:**

*   All forces of all bodies in the list of bodies are cleared.

Test Cases
----------

### Test Case 1: Clear forces for one body

**Test Data:**

*   List of bodies with one body.

**Test Steps:**

1.  Create a mock body object with the ```ClearForces``` method.
2.  Add the mock body object to the list of bodies.
3.  Call the ```ClearForces``` method on the physics engine.

**Expected Results:**

*   The ```ClearForces``` method is called on the mock body object.

**Unit Test:**

```csharp
/// <summary>
/// Tests that clear forces clears forces for one body
///</summary>
[Fact]
public void ClearForces_ClearsForcesForOneBody()
{
    Vector2F gravity = new Vector2F(0f, 9.18f);
    Vector2F position = new Vector2F(0f, 0f);
    Vector2F velocity = new Vector2F(0f, -1f);
    
    // Create a world object with the ClearForces method and 9.18f gravity.
    World world = new World(gravity);

    // Create a mock body object with the ClearForces method.
    Mock<Body> mockBody = new Mock<Body>(
        position, 
        velocity,
        BodyType.Dynamic,
        0.0f,
        0.0f,
        0.0f,
        0.0f,
        true,
        true,
        false,
        false,
        true,
        1.0f);

    // Call the ClearForces method on the physics engine.
    world.AddBody(mockBody.Object);

    // Call the ClearForces method on the word class
    world.ClearForces();
    
    // Assert that the ClearForces method is called on the mock body object.
    Assert.Single(world.Bodies);
    
    // Assert that the force is zero
    Assert.Equal(Vector2F.Zero, world.Bodies[0].Force);
    
    // Assert that the torque is zero
    Assert.Equal(0, world.Bodies[0].Torque);
    
    // Verify that the ClearForces method is called on the mock body object.
    mockBody.VerifyAll();
}
```

### Test Case 2: Clear forces for multiple bodies

**Test Data:**

*   List of bodies with multiple bodies.

**Test Steps:**

1.  Create mock body objects with the ```ClearForces``` method.
2.  Add the mock body objects to the list of bodies.
3.  Call the ```ClearForces``` method on the physics engine.

**Expected Results:**

*   The ```ClearForces``` method is called on all mock body objects.

**Unit Test:**

```csharp
/// <summary>
/// Tests that clear forces clears forces for multiple bodies
/// </summary>
[Fact]
public void ClearForces_ClearsForcesForMultipleBodies()
{
    Vector2F gravity = new Vector2F(0f, 9.18f);
    Vector2F position = new Vector2F(0f, 0f);
    Vector2F velocity = new Vector2F(0f, -1f);
    
    // Create a world object with the ClearForces method and 9.18f gravity.
    World world = new World(gravity);

    List<Mock<Body>> listMocksBodies = new List<Mock<Body>>();

    for (int i = 0; i < 10;i++)
    {
        Mock<Body> mockBody = new Mock<Body>(position, 
            velocity, 
            BodyType.Dynamic,
            0.0f,
            0.0f,
            0.0f,
            0.0f,
            true,
            true,
            false,
            false,
            true,
            1.0f);
        
        listMocksBodies.Add(mockBody);
        world.AddBody(mockBody.Object);
    }
    
    // Call the ClearForces method on the word class
    world.ClearForces();
    
    // Assert that is not empty bodies
    Assert.NotEmpty(world.Bodies);
    
    // Assert that is 10 bodies
    Assert.Equal(10, world.Bodies.Count);

    // Assert that all bodies set to zero force and torque
    for (int i = 0; i < 10; i++)
    {
        // Assert that the force is zero
        Assert.Equal(Vector2F.Zero, world.Bodies[i].Force);

        // Assert that the torque is zero
        Assert.Equal(0, world.Bodies[i].Torque);
    }
    
    // Verify that the ClearForces method is called on the mock body object.
    foreach (Mock<Body> mockBody in listMocksBodies)
    {
        mockBody.VerifyAll();
    }
}
```

### Test Case 3: Clear forces for empty list of bodies

**Test Data:**

*   Empty list of bodies.

**Test Steps:**

1.  Call the ```ClearForces``` method on the physics engine.

**Expected Results:**

*   No ```ClearForces``` method is called.

**Unit Test:**

```csharp
/// <summary>
/// Tests that clear forces does nothing with an empty list
/// </summary>
[Fact]
public void ClearForces_DoesNothingWithEmptyList()
{
    // Set the gravity to 9.18f
    Vector2F gravity = new Vector2F(0f, 9.18f);

    // Create a world object with the ClearForces method and 9.18f gravity.
    World world = new World(gravity);

    // Call the ClearForces method on the word class
    world.ClearForces();

    // Assert that is empty bodies
    Assert.Empty(world.Bodies);
}
```

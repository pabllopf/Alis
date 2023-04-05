# World

1. [Introduction](#introduction)
2. [Creating a World](#creating-a-world)
3. [World.AddBody](#worldaddbody)
   1. Use Cases
      1. [Use Case 1: Add a body to the world](#use-case-1-add-a-body-to-the-world)
   2. Test Cases
      1. [Test Case 1: Add a valid body to the world](#test-case-1-add-a-valid-body-to-the-world)
      2. [Test Case 2: Add a null body to the world](#test-case-2-add-a-null-body-to-the-world)
4. [World.ClearForces](#worldclearforces)
   1. Use Cases
      1. [Use Case 1: ClearForces with empty bodies list](#use-case-1-clearforces-with-empty-bodies-list)
      2. [Use Case 2: ClearForces with non-empty bodies list](#use-case-2-clearforces-with-non-empty-bodies-list)
   2. Test Cases
      1. [Test Case 1: ClearForces with empty bodies list](#test-case-1-clearforces-with-empty-bodies-list)
      2. [Test Case 2: ClearForces with non-empty bodies list](#test-case-2-clearforces-with-non-empty-bodies-list)

## Introduction 

The World class is a fundamental component of the graphics engine, responsible for managing the virtual world where all the objects, characters, and physics interact. It provides a central hub for controlling the simulation of the environment and the dynamics of the objects within it. The World class allows the creation, deletion, and manipulation of bodies, forces, and other physics-related elements, making it a crucial building block for any physics-based game or application. Its versatile design and efficient implementation make it an essential tool for creating immersive and interactive experiences.

### Creating a World

First, we define the gravity vector.

```csharp
    Vector2F gravity = new Vector2F(x: 0.0f, y: 9.8f);
```

Now we create the world object.

```csharp
    World myWorld = new World(gravity: gravity);
```
# World.AddBody

```csharp
/// <summary>
/// Adds the body using the specified body
/// </summary>
/// <param name="body">The body</param>
public void AddBody(Body body) => Bodies.Add(body);

```
## Uses Cases:
### Use case 1: Add a new body to an empty world
#### Preconditions


| id  | Preconditions           |
|-----|-------------------------|
| 1   | A new instance of World |
| 2   | No bodies in the World  |

#### Flow of Events
<table><thead><tr><th>id</th><th>Flow of Events</th></tr></thead><tbody><tr><td>1</td><td>Invoke `AddBody` method with a new instance of Body as parameter</td></tr></tbody></table>

#### Postconditions


| id  | Postconditions                           |
|-----|------------------------------------------|
| 1   | The World contains the new Body instance |

## Test Cases:
### Test case 1: Add a new body to an empty world
#### Test Data


| id  | Test Data               |
|-----|-------------------------|
| 1   | A new instance of World |
| 2   | A new instance of Body  |

#### Test Steps
<table><thead><tr><th>id</th><th>Test Steps</th></tr></thead><tbody><tr><td>1</td><td>Invoke `AddBody` method with the new instance of Body as parameter</td></tr></tbody></table>

#### Expected Results


| id  | Expected Results                         |
|-----|------------------------------------------|
| 1   | The World contains the new Body instance |

```csharp
[Fact]
public void Test_AddBody_When_AddingNewBodyToEmptyWorld_Expect_BodyAddedToWorld()
{
   throw new NotImplementedException();
}

```

-------------------
World.ClearForces
=================

```csharp

/// <summary>
/// Clear all forces
/// </summary>
internal void ClearForces() => Bodies.ForEach(i => i.ClearForces());

```


Use Cases:
----------

### Use Case 1: ClearForces with empty bodies list

#### Preconditions:

*   World object with an empty Bodies list.

#### Flow of Events:

1.  Call the ClearForces method.

#### Postconditions:

*   The Bodies list remains empty.

### Use Case 2: ClearForces with non-empty bodies list

#### Preconditions:

*   World object with a non-empty Bodies list.

#### Flow of Events:

1.  Add a set of forces to the bodies list.
2.  Call the ClearForces method.

#### Postconditions:

*   The Bodies list contains no forces.

Test Cases:
-----------

### Test Case 1: ClearForces with empty bodies list

#### Test Data:

*   Empty Bodies list.

#### Test Steps:

1.  Call the ClearForces method.

#### Expected Results:

*   No exception should be thrown.

```csharp

[Fact]
public void Test_ClearForces_When_EmptyBodiesList_Expect_NoExceptionThrown()
{
   throw new NotImplementedException();
}

```

### Test Case 2: ClearForces with non-empty bodies list

#### Test Data:

*   Bodies list with a set of forces.

#### Test Steps:

1.  Call the ClearForces method.

#### Expected Results:

*   All forces are removed from the Bodies list.


```csharp

[Fact]
public void Test_ClearForces_When_NonEmptyBodiesList_Expect_ForcesRemoved()
{
   throw new NotImplementedException();
}
```



<style>
    table {
        width: 100%;
    }
</style>

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
### Use case 1: Add a body to the world

<table><thead><tr><th>Preconditions</th><th>Flow of Events</th><th>Postconditions</th></tr></thead><tbody><tr><td>The world exists</td><td>1. User calls AddBody with a valid body object <br> 2. Method adds the body to the world's list of bodies</td><td>The world's list of bodies includes the new body object</td></tr></tbody></table>

### Use case 2: Add multiple bodies to the world

<table><thead><tr><th>Preconditions</th><th>Flow of Events</th><th>Postconditions</th></tr></thead><tbody><tr><td>The world exists</td><td>1. User calls AddBody multiple times with valid body objects <br> 2. Method adds each body to the world's list of bodies</td><td>The world's list of bodies includes all new body objects</td></tr></tbody></table>

## Test Cases:
### Test case 1: Add a single body to the world


| Test Data           | Test Steps                           | Expected Results                                        |
|---------------------|--------------------------------------|---------------------------------------------------------|
| A valid body object | 1. Call AddBody with the body object | The world's list of bodies includes the new body object |

```csharp
[Fact]
public void Test_AddBody_When_StateUnderTest_Expect_ExpectedBehavior()
{
    throw new NotImplementedException();
}

```

### Test case 2: Add multiple bodies to the world

<table><thead><tr><th>Test Data</th><th>Test Steps</th><th>Expected Results</th></tr></thead><tbody><tr><td>Two valid body objects</td><td>1. Call AddBody with the first body object <br> 2. Call AddBody with the second body object</td><td>The world's list of bodies includes both body objects</td></tr></tbody></table>

```csharp
[Fact]
public void Test_AddBody_When_StateUnderTest_Expect_ExpectedBehavior()
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



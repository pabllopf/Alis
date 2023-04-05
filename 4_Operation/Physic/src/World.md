# World

1. [Introduction](#introduction)
2. [Creating a World](#creating-a-world)
3. [World.AddBody](#worldaddbody)
    1. [Uses Cases:](#uses-cases)
        1. [Use case 1: Add a body to the world](#use-case-1-add-a-body-to-the-world)
        2. [Use case 2: Add a null body to the world](#use-case-2-add-a-null-body-to-the-world)
        3. [Use case 3: Add an existing body to the world](#use-case-3-add-an-existing-body-to-the-world)
    2. [Test Cases:](#test-cases)
        1. [Test case 1: Add a body to the world](#test-case-1-add-a-body-to-the-world)
        2. [Test case 2: Add a null body to the world](#test-case-2-add-a-null-body-to-the-world)
        3. [Test case 3: Add an existing body to the world](#test-case-3-add-an-existing-body-to-the-world)
4. [World.ClearForces](#worldclearforces)
    1. [Uses Cases:](#uses-cases-1)
        1. [Use Case 1: Clear all forces](#use-case-1-clear-all-forces)
        2. [Use Case 2: No bodies with forces applied](#use-case-2-no-bodies-with-forces-applied)
    2. [Test Cases:](#test-cases-1)
        1. [Test case 1: Clear forces for all bodies](#test-case-1-clear-forces-for-all-bodies)
        2. [Test Case 2: No bodies with forces applied](#test-case-2-no-bodies-with-forces-applied)



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

| Preconditions     | Flow of Events     | Postconditions                  |
|-------------------|--------------------|---------------------------------|
| The world exists. | A body is created. | The body is added to the world. |

### Use case 2: Add a null body to the world


| Preconditions     | Flow of Events          | Postconditions                      |
|-------------------|-------------------------|-------------------------------------|
| The world exists. | A null body is created. | An ArgumentNullException is thrown. |

### Use case 3: Add an existing body to the world


| Preconditions     | Flow of Events                        | Postconditions                        |
|-------------------|---------------------------------------|---------------------------------------|
| The world exists. | A body already in the world is added. | The body is added again to the world. |

## Test Cases:
### Test case 1: Add a body to the world


| Test Data                                   | Test Steps                        | Expected Results                |
|---------------------------------------------|-----------------------------------|---------------------------------|
| A world with no bodies. A body to be added. | 1. Call the method AddBody(body). | The body is added to the world. |

```csharp
[Fact]
public void Test_AddBody_When_WorldExistsAndBodyIsNotNull_Expect_BodyAddedToWorld()
{
   throw new NotImplementedException();
}

```
### Test case 2: Add a null body to the world


| Test Data                                        | Test Steps                        | Expected Results                    |
|--------------------------------------------------|-----------------------------------|-------------------------------------|
| A world with no bodies. A null body to be added. | 1. Call the method AddBody(null). | An ArgumentNullException is thrown. |

```csharp
[Fact]
public void Test_AddBody_When_WorldExistsAndBodyIsNull_Expect_ArgumentNullExceptionThrown()
{
   throw new NotImplementedException();
}

```
### Test case 3: Add an existing body to the world


| Test Data                                         | Test Steps                        | Expected Results                      |
|---------------------------------------------------|-----------------------------------|---------------------------------------|
| A world with one body. The same body to be added. | 1. Call the method AddBody(body). | The body is added again to the world. |

```csharp
[Fact]
public void Test_AddBody_When_WorldExistsAndBodyAlreadyInWorld_Expect_BodyAddedAgainToWorld()
{
   throw new NotImplementedException();
}

```


 --------

















# World.ClearForces

```csharp
/// <summary>
/// Clear all forces
/// </summary>
internal void ClearForces() => Bodies.ForEach(i => i.ClearForces());

```

## Uses Cases:
### Use Case 1: Clear all forces


| Preconditions                                    | Flow of Events     | Postconditions                       |
|--------------------------------------------------|--------------------|--------------------------------------|
| There are one or more bodies with forces applied | Call ClearForces() | All forces of all bodies are cleared |

### Use Case 2: No bodies with forces applied


| Preconditions                           | Flow of Events     | Postconditions     |
|-----------------------------------------|--------------------|--------------------|
| There are no bodies with forces applied | Call ClearForces() | There is no change |

## Test Cases:

### Test case 1: Clear forces for all bodies


| Test Data                                         | Test Steps                        | Expected Results                                  |
|---------------------------------------------------|-----------------------------------|---------------------------------------------------|
| A world with 5 bodies and forces applied to them. | 1. Call the method ClearForces(). | All forces of each body in the world are cleared. |

```csharp
[Fact]
public void Test_ClearForces_When_WorldContainsBodiesWithForces_Expect_ForcesCleared()
{
   throw new NotImplementedException();
}

```

### Test Case 2: No bodies with forces applied


| Test Data            | Test Steps         | Expected Results   |
|----------------------|--------------------|--------------------|
| List of empty bodies | Call ClearForces() | There is no change |

```csharp
[Fact]
public void Test_ClearForces_When_NoForcesApplied_Expect_NoChange()
{
    throw new NotImplementedException();
}

```





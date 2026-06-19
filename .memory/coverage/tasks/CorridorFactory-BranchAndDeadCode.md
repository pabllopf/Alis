## COVERAGE TASK

### File
1_Presentation/Extension/Math/ProceduralDungeon/src/Services/CorridorFactory.cs

### Coverage
96.4% (1 uncovered line, 1 uncovered condition)

### Uncovered Items
- Line 166: duplicate `return newDirection;` — dead code (unreachable)
- Branch: `while (newDirection == oppositeDirection)` — only the exit branch is tested; the re-enter branch is never exercised

### Method
GetRandomDirectionAvoidingOpposite (private)

### Existing Tests
CorridorFactoryTest.cs — covers constructor (null RNG throws), CreateFirstCorridor (North, West, zero/negative dimensions), CreateCorridor (zero/negative dimensions, avoids opposite), MultipleCalls

### Fix
1. Remove duplicate `return newDirection;` on line 166 (dead code bug)
2. Add test that forces the while loop to iterate by returning the opposite direction on first RNG call, then a non-opposite on second call

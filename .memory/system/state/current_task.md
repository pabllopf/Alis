
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 173 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/Kernel/CommandBuffer.cs

    ### Language
    cs

    ### Coverage
    96.8% (Line: 96.7%, Branch: 97.4%)

    ### Uncovered Lines
    6

    ### Uncovered Branches
    1

    ### Method
    CommandBuffer

    ### Complexity / LOC
    44 / 226 lines

    ### Source Code
    ```csharp
    // [Source code omitted. Use --fetch-source to extract.]
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/Kernel/CommandBufferTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/Kernel/CommandBuffer.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage CommandBuffer.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

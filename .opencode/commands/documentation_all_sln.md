````markdown id="8x1mvn"
# MODEL-DRIVEN PROCESSING RULE (CRITICAL)

The model itself MUST perform the analysis and reasoning directly.

STRICTLY FORBIDDEN:

- Generating custom Python scripts
- Generating helper C# projects
- Generating Roslyn automation tooling
- Generating repository-wide analyzers
- Creating temporary CLI utilities
- Creating external parsers
- Creating transformation frameworks
- Creating batch-processing automation
- Creating intermediate processing pipelines

The agent MUST NOT solve the task by creating additional tooling.

---

# DIRECT FILE READING RULE

The model MUST:

- Read each `.cs` file directly
- Read the COMPLETE file contents before modifying anything
- Understand the file holistically before generating documentation
- Infer behavior using senior-level engineering reasoning
- Analyze symbol relationships only within the current file unless absolutely necessary

---

# SENIOR ENGINEERING DOCUMENTATION RULE

Documentation quality MUST reflect the standards of a senior enterprise software engineer.

Generated XML documentation MUST:

- Be concise
- Be technically accurate
- Avoid redundant wording
- Avoid generic filler text
- Explain observable responsibilities clearly
- Match enterprise-grade .NET documentation conventions
- Avoid obvious statements
- Avoid hallucinated implementation details

BAD EXAMPLE:

```csharp
/// <summary>
/// Gets the user.
/// </summary>
```

GOOD EXAMPLE:

```csharp
/// <summary>
/// Retrieves the authenticated user associated with the current session.
/// </summary>
```

---

# FULL-FILE CONTEXT RULE

Before documenting any symbol:

The model MUST:

1. Read the entire file
2. Understand class responsibilities
3. Understand symbol relationships
4. Understand dependency flow within the file
5. Only then generate XML documentation

However:

- Documentation MUST remain symbol-local
- No cross-symbol XML reuse is allowed

---

# LANGUAGE RULE (MANDATORY)

ALL generated documentation MUST be written in ENGLISH ONLY.

This includes:

- `<summary>`
- `<param>`
- `<returns>`
- `<exception>`
- inline replacement comments if added
- git commit descriptions
- JSON metadata descriptions

NEVER generate documentation in another language.

---

# PERSISTENT CACHE DIRECTORY

ALL state tracking MUST be stored inside:

```text
.opencode/cache/
```

---

# REQUIRED CACHE FILE

Path:

```text
.opencode/cache/processed_files.json
```

---

# CACHE OBJECT FORMAT (MANDATORY)

Each processed file MUST contain:

- processing state
- first read timestamp
- last processed timestamp
- whether modifications were applied
- commit message
- XML metrics
- comment cleanup metrics

Example:

```json
{
  "src/Application/AuthService.cs": {
    "status": "completed",
    "first_read_at": "2026-05-23T10:12:11Z",
    "last_processed_at": "2026-05-23T10:14:02Z",
    "modified": true,
    "xml_added": 12,
    "xml_updated": 4,
    "comments_removed": 3,
    "commit": "docs: AuthService.cs add XML documentation for authentication workflows"
  },
  "src/Domain/ValueObjects/Email.cs": {
    "status": "completed",
    "first_read_at": "2026-05-23T10:20:10Z",
    "last_processed_at": "2026-05-23T10:20:10Z",
    "modified": false,
    "xml_added": 0,
    "xml_updated": 0,
    "comments_removed": 0,
    "commit": null
  }
}
```

---

# CACHE REUSE RULE (CRITICAL)

This prompt is expected to run MULTIPLE TIMES across the same repository.

Before processing ANY file:

1. Load `.opencode/cache/processed_files.json`
2. Check if the file already exists
3. If status is `"completed"`:
   - SKIP the file entirely
   - DO NOT re-read it
   - DO NOT reprocess it
   - DO NOT regenerate documentation

---

# RESUMABLE EXECUTION RULE

The execution MUST support interruption and continuation safely.

If the session stops unexpectedly:

- previously completed files MUST remain skipped
- already processed files MUST NOT be re-evaluated
- processing MUST resume from remaining files only

---

# MODIFICATION DECISION RULE

If a file already contains:

- high-quality XML documentation
- meaningful comments
- correct documentation structure

Then:

- DO NOT force changes
- DO NOT rewrite documentation unnecessarily
- Mark file as `"modified": false`

---

# GIT COMMIT RULE

Create EXACTLY ONE commit per modified file.

Format:

```text
docs: Filename.cs <technical-description>
```

Examples:

```text
docs: UserService.cs add XML documentation for authentication operations

docs: InvoiceRepository.cs document repository query methods

docs: CacheProvider.cs remove redundant inline comments and add missing XML docs
```

---

# COMMIT MESSAGE LANGUAGE RULE

ALL commit messages MUST be written in ENGLISH.

---

# FINAL EXECUTION GOAL

Produce a repository that is:

- fully documented
- enterprise-grade
- resumable
- deterministic
- safe for repeated executions
- traceable through JSON cache state
- incrementally committed
- free from unnecessary comment noise

while guaranteeing:

- zero runtime behavior changes
- zero structural refactoring
- zero speculative modifications
- zero helper tooling generation
- direct model-driven reasoning only
````

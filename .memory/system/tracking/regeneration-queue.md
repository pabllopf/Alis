# Regeneration Queue

## Pending Regeneration

| Artifact | Reason | Priority | Status |
|----------|--------|----------|--------|
| Application project docs | Not yet generated | High | Pending |
| Sample project docs | Not yet generated | High | Pending |
| Dependency diagrams | New projects documented | Medium | Pending |
| Architecture overview | Update with new understanding | Medium | Pending |
| AI context files | Update with all projects | Low | Pending |

## Regeneration Rules
- Regenerate ONLY when source code changes
- Regenerate ONLY when dependencies change
- Skip if generated output hash unchanged
- Preserve manual content sections

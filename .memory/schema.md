---
title: LLM Wiki Schema
tags:
  - documentation
  - reference

status: draft

license: GPLv3
---


## Structure

```
.memory/
├── index.md          # Content-oriented catalog of all pages
├── log.md            # Append-only chronological activity log
├── schema.md         # This file — conventions and workflows
├── raw/              # Immutable source documents (never modified)
├── entities/         # Entity pages (people, organizations, tools)
├── concepts/         # Concept pages (ideas, patterns, theories)
└── sources/          # Source summaries (ingested documents)
```

## Conventions

### Page format
- Markdown files with `[[wikilinks]]` for cross-references
- Optional YAML frontmatter: `tags`, `date`, `sources` (count)
- Entity pages: name, type, key facts, related concepts
- Concept pages: definition, evolution, related entities, sources
- Source summaries: title, date, key takeaways, pages updated

### Cross-references
- Use `[[Page Name]]` syntax for internal links
- Every entity page should link to at least one concept
- Every concept page should cite its sources

### Index maintenance
- Update `index.md` on every ingest
- Each entry: `[[link]] — one-line summary`
- Organized by category (entities, concepts, sources)

### Log format
- Entries: `## [YYYY-MM-DD] operation | title`
- Operations: `ingest`, `query`, `lint`
- Parseable with grep: `grep "^## \[" log.md | tail -5`

## Workflows

### Ingest
1. LLM reads source from `raw/`
2. Discusses key takeaways with user
3. Writes summary in `sources/`
4. Updates `index.md`
5. Updates relevant entity and concept pages
6. Appends entry to `log.md`

### Query
1. LLM reads `index.md` to find relevant pages
2. Reads and synthesizes from wiki pages
3. Answers with citations
4. Files valuable answers back as new pages

### Lint (periodic)
1. Check for contradictions between pages
2. Find stale claims superseded by newer sources
3. Identify orphan pages with no inbound links
4. Flag concepts mentioned but lacking pages
5. Suggest new sources to investigate

## Related

- [[analysis-state]] — Current analysis state
- [[coverage-map]] — Documentation coverage tracking
- [[documentation-map]] — Documentation file mapping
- [[index]] — Memory system index
- [[log]] — Session activity log
- [[execution-log]] — Detailed execution history

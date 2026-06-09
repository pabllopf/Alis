---
title: 5_Declaration Layer Overview
tags: [declaration,contract,interface,documentation]
---


## Overview
The Declaration layer (`5_Declaration`) contains the aspect system aggregator. Zero hand-written code — pure aggregator that consolidates all generated types from 6_Ideation and 4_Operation generators into a single assembly consumed by 3_Structuration.

## Projects

| Project | Type | Hand-Written Code |
|---|---|---|
| [[projects/5_Declaration/Aspect\|Alis.Core.Aspect]] | Aggregator (Aspect System) | Zero — pure aggregation |
| Alis.Core.Aspect.Test | Test suite | Tests |
| Alis.Core.Aspect.Sample | Usage samples | Samples |

## Dependencies
This layer depends on nothing (leaf for hand-written code) but **consumes** generated output from:
- All 6_Ideation generators (Memory, Fluent, Data, Math, Time, Logging)
- All 4_Operation generators (ECS, Graphic)

## Notes
- Earlier versions of this index referenced `Alis.Core.Data` and `Alis.Core.Log` as 5_Declaration projects — these are actually aspects in 6_Ideation ([[projects/6_Ideation/Data]], [[projects/6_Ideation/Logging]])
- Generator references use dynamic glob patterns in MSBuild

## Related
- [[projects/5_Declaration/Aspect]] — Aspect aggregator
- [[projects/Generators]] — Generator overview
- [[system/indexes/layer-index]] — Layer breakdown
- [[system/indexes/dependency-index]] — Generator cascade

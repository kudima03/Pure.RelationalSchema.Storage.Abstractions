# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet build --no-restore -warnaserror
dotnet format --verify-no-changes             # check code style (CI enforces this)
dotnet format                                  # auto-fix code style
dotnet pack --configuration Release -p:PackageVersion=<version> --output .
```

There are no test or benchmark projects — the CI pipeline only builds and checks formatting.

## Architecture

This is an **interfaces-only NuGet library** — no implementations, no tests. Every file defines
exactly one interface.

**Interface hierarchy:**

- `ICell` — wraps a single `IString` value representing one database cell
- `IRow` — maps `IColumn` → `ICell` for a single row via `IReadOnlyDictionary<IColumn, ICell>`
- `IStoredTableDataSet` — extends both `IQueryable<IRow>` and `IAsyncEnumerable<IRow>`; carries
  `ITable TableSchema` identifying which table the data belongs to
- `IStoredSchemaDataSet` — extends `IReadOnlyDictionary<ITable, IStoredTableDataSet>`; carries
  `ISchema Schema` for the full schema

`IColumn`, `ITable`, and `ISchema` are defined in `Pure.RelationalSchema.Abstractions` (the
schema-description layer). This package sits above it, adding the data-access layer on top of
those structural abstractions.

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. All interfaces must remain AOT-compatible
(`IsAotCompatible=true`).

**Publishing:** triggered by pushing a semver tag (e.g. `1.0.0`). The tag name becomes the
`PackageVersion`. Packages are published to both GitHub Packages and NuGet.org.

## Code Style

Enforced via `.editorconfig` and `dotnet format --verify-no-changes` in CI:

- No `var` — always use explicit types
- File-scoped namespaces required (`csharp_style_namespace_declarations = file_scoped`)
- Expression-bodied members on properties, indexers, and accessors; block bodies on methods and
  constructors
- `using` directives must appear outside the namespace
- Braces required for all code blocks
- Implicit object creation disallowed — `new SomeType()` not `new()`
- Max line length: 90 characters

## Commit Messages

Do not mention Claude or AI assistance in commit messages.

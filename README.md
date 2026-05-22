# Pure.RelationalSchema.Storage.Abstractions

Base interfaces for reading stored relational schema data in the **Pure** ecosystem.

[![.NET build & test](https://github.com/kudima03/Pure.RelationalSchema.Storage.Abstractions/actions/workflows/build-and-check.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.Storage.Abstractions/actions/workflows/build-and-check.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.RelationalSchema.Storage.Abstractions/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.Storage.Abstractions/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.RelationalSchema.Storage.Abstractions)](https://www.nuget.org/packages/Pure.RelationalSchema.Storage.Abstractions)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.RelationalSchema.Storage.Abstractions` defines a set of minimal, read-only interfaces for
accessing data persisted in a relational schema store. Consumers code against
`IStoredSchemaDataSet` and `IStoredTableDataSet` without coupling to any particular database
technology.

## Interfaces

| Name | Namespace | Description |
|------|-----------|-------------|
| `ICell` | `Pure.RelationalSchema.Storage.Abstractions` | A single cell value in a row, exposed as `IString` |
| `IRow` | `Pure.RelationalSchema.Storage.Abstractions` | A row of cells keyed by column schema (`IReadOnlyDictionary<IColumn, ICell>`) |
| `IStoredTableDataSet` | `Pure.RelationalSchema.Storage.Abstractions` | Queryable and async-enumerable dataset for a single table; carries its `ITable` schema |
| `IStoredSchemaDataSet` | `Pure.RelationalSchema.Storage.Abstractions` | Read-only dictionary of table datasets keyed by `ITable`; carries its `ISchema` |

## Design Principles

- **Interfaces-only** — no implementations, no business logic; every file defines exactly one
  interface
- **AOT-compatible** — all interfaces are safe for ahead-of-time compilation
- **Schema-driven** — data access is always scoped to a typed schema; raw string column names
  are never used

## Dependencies

- [`Pure.RelationalSchema.Abstractions`](https://github.com/kudima03/Pure.RelationalSchema.Abstractions/tree/1.2.0) —
  interfaces describing the relational schema structure: tables, columns, indices, and foreign keys

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```
dotnet add package Pure.RelationalSchema.Storage.Abstractions
```

## Usage

```csharp
async Task ReadAll(IStoredSchemaDataSet dataSet)
{
    foreach (ITable table in dataSet.Schema.Tables)
    {
        IStoredTableDataSet tableData = dataSet[table];

        await foreach (IRow row in tableData)
        {
            foreach ((IColumn column, ICell cell) in row.Cells)
            {
                Console.WriteLine($"{column.Name}: {cell.Value}");
            }
        }
    }
}
```

# Changelog

All notable changes to Pure.RelationalSchema.Storage.Abstractions are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.4.1.0] — 2025-12-06

### Added

- Multi-targeting for `net7.0`, `net8.0`, `net9.0`, and `net10.0` (previously
  `net9.0` only).

### Changed

- Declared the package as Native AOT compatible (`IsAotCompatible`) in place
  of the separate trim/AOT analyzer settings used previously.

## [0.1.0-preview.4.0.0] — 2025-10-15

### Added

- **`IStoredSchemaDataSet.Schema`** — exposes the `ISchema` the stored
  dataset belongs to.

### Changed

- **Breaking:** `IStoredSchemaDataSet.TablesDatasets` removed; the interface
  now implements `IReadOnlyDictionary<ITable, IStoredTableDataSet>` directly
  instead of exposing it via a property.

## [0.1.0-preview.3.0.0] — 2025-09-26

### Changed

- Enabled trimming and Native AOT analyzers (`IsTrimmable`,
  `EnableTrimAnalyzer`, `EnableAotAnalyzer`) to verify trim/AOT compatibility
  at build time.

## [0.1.0-preview.2.1.0] — 2025-08-21

- Maintenance release: dependency and build updates.

## [0.1.0-preview.2.0.0] — 2025-08-11

### Changed

- **Breaking:** `IStoredTableDataSet` base changed back from
  `IEnumerable<IRow>` to `IQueryable<IRow>`, reverting the previous release.

## [0.1.0-preview.1.0.0] — 2025-08-11

### Changed

- **Breaking:** `IStoredTableDataSet` base changed from `IQueryable<IRow>` to
  `IEnumerable<IRow>`.

## [0.1.0-preview.0.1.0] — 2025-08-06

### Added

Initial release of the interfaces-only data-access layer sitting above
`Pure.RelationalSchema.Abstractions`:

- **`ICell`** — wraps a single `IString` value representing one database
  cell.
- **`IRow`** — maps `IColumn` to `ICell` via
  `IReadOnlyDictionary<IColumn, ICell>`.
- **`IStoredTableDataSet`** — extends `IQueryable<IRow>` and
  `IAsyncEnumerable<IRow>`; carries `ITable TableSchema` identifying the
  table the data belongs to.
- **`IStoredSchemaDataSet`** — exposes
  `IReadOnlyDictionary<ITable, IStoredTableDataSet> TablesDatasets`.

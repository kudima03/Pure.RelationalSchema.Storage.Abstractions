using Pure.RelationalSchema.Abstractions.Table;

namespace Pure.RelationalSchema.Storage.Abstractions;

public interface IStoredSchemaDataSet
{
    IDictionary<ITable, IStoredTableDataSet> TablesDatasets { get; }
}

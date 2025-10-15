using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;

namespace Pure.RelationalSchema.Storage.Abstractions;

public interface IStoredSchemaDataSet : IReadOnlyDictionary<ITable, IStoredTableDataSet>
{
    ISchema Schema { get; }
}

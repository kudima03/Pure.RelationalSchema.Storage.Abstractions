using Pure.RelationalSchema.Abstractions.Table;

namespace Pure.RelationalSchema.Storage.Abstractions;

public interface IStoredTableDataSet : IEnumerable<IRow>, IAsyncEnumerable<IRow>
{
    ITable TableSchema { get; }
}

using Pure.RelationalSchema.Abstractions.Schema;

namespace Pure.RelationalSchema.Storage.Abstractions;

public interface IStoredDataSet : IQueryable<IResultSet>, IAsyncEnumerable<IResultSet>
{
    ISchema Schema { get; }
}

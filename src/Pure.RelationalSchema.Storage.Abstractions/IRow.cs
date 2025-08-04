using Pure.RelationalSchema.Abstractions.Column;

namespace Pure.RelationalSchema.Storage.Abstractions;

public interface IRow
{
    public IDictionary<IColumn, ICell> Cells { get; }
}

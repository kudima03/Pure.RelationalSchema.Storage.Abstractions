using Pure.RelationalSchema.Abstractions.Column;

namespace Pure.RelationalSchema.Storage.Abstractions;

public interface IRow
{
    IReadOnlyDictionary<IColumn, ICell> Cells { get; }
}

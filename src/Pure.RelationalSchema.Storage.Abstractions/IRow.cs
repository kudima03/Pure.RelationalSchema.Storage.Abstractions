using Pure.RelationalSchema.Abstractions.Column;

namespace Pure.RelationalSchema.Storage.Abstractions;

public interface IRow
{
    IDictionary<IColumn, ICell> Cells { get; }
}

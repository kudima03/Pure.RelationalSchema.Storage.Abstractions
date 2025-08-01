using Pure.RelationalSchema.Abstractions.Column;

namespace Pure.RelationalSchema.Storage.Abstractions;

public interface ICell
{
    IRow Row { get; }

    IColumn Column { get; }

    object Value { get; }
}

public interface ICell<out T> : ICell
{
    T TypedValue { get; }
}

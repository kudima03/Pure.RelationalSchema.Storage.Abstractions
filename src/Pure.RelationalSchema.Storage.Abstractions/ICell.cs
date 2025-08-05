using Pure.Primitives.Abstractions.String;

namespace Pure.RelationalSchema.Storage.Abstractions;

public interface ICell
{
    IString Value { get; }
}

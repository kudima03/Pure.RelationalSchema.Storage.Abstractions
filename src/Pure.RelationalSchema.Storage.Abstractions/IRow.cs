namespace Pure.RelationalSchema.Storage.Abstractions;

public interface IRow
{
    IEnumerable<ICell> Cells { get; }
}

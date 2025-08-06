namespace Pure.RelationalSchema.Storage.Abstractions;

public interface IRowsQueryable<out TRow> : IQueryable<TRow> where TRow : IRow
{
    IRowsQueryProvider<TRow> RowsQueryProvider { get; }
}

namespace Pure.RelationalSchema.Storage.Abstractions;

public interface IRowsQueryProvider<out TRow> : IQueryProvider where TRow : IRow;

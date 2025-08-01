namespace Pure.RelationalSchema.Storage.Abstractions;

public interface IResultSet : IEnumerable<IRow>, IAsyncEnumerable<IRow>;

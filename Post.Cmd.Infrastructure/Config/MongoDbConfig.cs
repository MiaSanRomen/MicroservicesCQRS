namespace Post.Cmd.Infrastructure.Config;

public sealed record MongoDbConfig(
    string ConnectionString,
    string Database,
    string Collection);
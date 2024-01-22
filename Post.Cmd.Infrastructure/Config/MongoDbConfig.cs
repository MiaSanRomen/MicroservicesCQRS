namespace Post.Cmd.Infrastructure.Config;

public sealed record MongoDbConfig
{
    public MongoDbConfig()
    {
    }

    public string ConnectionString { get; init; }
    public string Database { get; init; }
    public string Collection { get; init; }
}
using StackExchange.Redis;

public class ConnectBasicExample
{

    public void run()
    {
        var muxer = ConnectionMultiplexer.Connect(
            new ConfigurationOptions
            {
                EndPoints = { { "redis-13910.crce185.ap-seast-1-1.ec2.redns.redis-cloud.com", 13910 } },
                User = "default",
                Password = "TZQbYDYpnsvGAcOee52YhveGO7ug7Apn"
            }
        );
        var db = muxer.GetDatabase();
        RedisValue result = db.StringGet("foo");
        Console.WriteLine(result); // >>> bar

    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ConnectBasicExample example = new ConnectBasicExample();
        example.run();
    }
}
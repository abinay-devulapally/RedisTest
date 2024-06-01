using System.Configuration;
using StackExchange.Redis;

namespace RedisTest
{
    internal class Program
    {
        private static string _connectionString = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            _connectionString = ConfigurationManager.AppSettings["CacheConnection"].ToString();

            ConnectionMultiplexer newConnection = ConnectionMultiplexer.Connect(_connectionString);

            IDatabase db = newConnection.GetDatabase();

            db.StringSet("mynewkey", "This is my test value");

            string value = db.StringGet("mynewkey");

            Console.WriteLine(value);
        }
    }
}

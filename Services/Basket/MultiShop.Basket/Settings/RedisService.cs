using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
	public class RedisService
	{
		public string _host;
		public int _port;
		private ConnectionMultiplexer _connectionMultiplexer;
		public RedisService(string host, int port)
		{
			_host = host;
			_port = port;
		}

		public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
		public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
	}
}
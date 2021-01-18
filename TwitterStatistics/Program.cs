using System;
using TwitterStatistics.Infrastructure;

namespace TwitterStatistics
{
	class Program
	{
		static void Main(string[] args)
		{
			StatisticManager manager = new StatisticManager(args[0], new Uri(@"https://api.twitter.com/2/tweets/sample/stream"));
			manager.Start();
		}
	}
}

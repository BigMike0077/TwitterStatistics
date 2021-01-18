using System;

namespace TwitterStatistics.Infrastructure
{
	public interface IManager
	{
		void Start();
		void Stop();
		void OnRenderStatistics(object sender, TweetEventArgs args);
	}
}

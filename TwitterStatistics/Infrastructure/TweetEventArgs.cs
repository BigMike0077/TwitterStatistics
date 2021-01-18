using System;

namespace TwitterStatistics.Infrastructure
{
	public class TweetEventArgs : EventArgs
	{
		public TweetEventArgs()
		{
		}

		public string TweetStr { get; set; }
	}
}

using System;
using System.Collections.Generic;

namespace TwitterStatistics.Models
{
	public class Statistics
	{
		public Statistics()
		{
			EmojiMap = new Dictionary<long, long>();
			StartDateTime = DateTime.Now;
		}

		public long TotalTweets { get; set; }
		public long HttpTweets { get; set; }
		public long HashtagTweets { get; set; }
		public long TotalSeconds { get; set; }
		public long TotalMinutes { get; set; }
		public long TotalHours { get; set; }
		public DateTime StartDateTime { get; private set; }

		public IDictionary<long, long> EmojiMap { get; set; }
	}
}

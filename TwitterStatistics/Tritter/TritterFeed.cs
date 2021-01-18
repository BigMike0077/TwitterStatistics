using System;
using System.IO;
using System.Net;
using TwitterStatistics.Infrastructure;

namespace TwitterStatistics
{
	public class TritterFeed : WebClient
	{
		public event EventHandler<TweetEventArgs> ProcessTweet;

		public TritterFeed(string bearer) : base()
		{
			Bearer = bearer;
			Headers.Add("Authorization", $"Bearer {bearer}");
		}

		public string Bearer { get; private set; }

		protected override void OnOpenReadCompleted(OpenReadCompletedEventArgs e)
		{
			Stream reply = null;
			StreamReader s = null;
			TweetEventArgs eventArgs = new TweetEventArgs();
			try
			{
				reply = e.Result;
				s = new StreamReader(reply);
				while (!s.EndOfStream)
				{
					eventArgs.TweetStr = s.ReadLine();
					ProcessTweet(this, eventArgs);
				}
			}
			finally
			{
				if (s != null)
				{
					s.Close();
				}

				if (reply != null)
				{
					reply.Close();
				}
			}
		}
	}
}

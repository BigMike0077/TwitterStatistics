using System;
using System.Text.Json;
using EmojiData;
using EmojiData.Models;
using TwitterStatistics.Models;
using TwitterStatistics.UI;

namespace TwitterStatistics.Infrastructure
{
	public class StatisticManager : IManager
	{
		public StatisticManager(string bearer, Uri uri)
		{
			Uri = uri;
			Page = new StatisticsPage();
			Feed = new TritterFeed(bearer);
			Stats = new Statistics();
			Emojior = new EmojiProcessor();
		}

		private EmojiProcessor Emojior { get; set; }
		private StatisticsPage Page { get; set; }
		private Statistics Stats { get; set; }
		private TritterFeed Feed { get; set; }
		private Uri Uri { get; set; }
		private int RenderCounter = 0;

		public void Start()
		{
			if (!string.IsNullOrEmpty(Feed.Bearer))
			{
				Feed.ProcessTweet += OnRenderStatistics;

				Feed.OpenReadAsync(Uri);
				Page.Init();
			}
			else
			{
				Page.RenderText("Input parameter 'bearer' is required");
				Page.RenderText("");
				Page.RenderText("Press any key to terminate program");
			}
		}

		public void Stop()
		{
			Feed.CancelAsync();
			Page.RenderText("Bye!");
		}

		public void OnRenderStatistics(object sender, TweetEventArgs args)
		{
			Stats.TotalTweets++;
			RenderCounter++;

			Tweet tweet = ToTweet(args.TweetStr);
			if (tweet != null)
			{
				FindUrls(tweet);
				FindEmojis(tweet);
			}

			if (RenderCounter >= 100)
			{
				RenderCounter = 0;
				Page.RenderStatistics(Stats);
			}
		}

		private Tweet FindEmojis(Tweet tweet)
		{
			Emoji[] emojis = Emojior.FingEmojis(tweet.data.text);
			return tweet;
		}

		private Tweet FindUrls(Tweet tweet)
		{
			if (tweet.data != null && tweet.data.text != null)
			{
				//Page.RenderText(tweet.data.text);
				if (tweet.data.text.Contains("http"))
				{
					Stats.HttpTweets++;
				}
			}
			return tweet;
		}

		private static Tweet ToTweet(string input)
		{
			Tweet tweet;
			try
			{
				tweet = JsonSerializer.Deserialize<Tweet>(input);
				tweet.dateTime = DateTime.Now;
			}
			catch
			{
				tweet = null;
			}
			return tweet;
		}
	}
}

using System;
using System.Globalization;
using System.Text;
using TwitterStatistics.Models;

namespace TwitterStatistics.UI
{
	public class StatisticsPage : IPage
	{
		#region Constructors

		public StatisticsPage()
		{
		}

		#endregion

		#region Public Methods

		public void Init()
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Blue;

			Console.Clear();

			Console.WriteLine("And So It Begins!");

			_ = Console.ReadLine();
		}

		public void RenderStatistics(Statistics stats)
		{
			TimeSpan interval = DateTime.Now - stats.StartDateTime;
			string underConstruction = "Under Construction";

			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.Clear();

			Console.WriteLine(" < Tweet Statistics > ");

			Console.WriteLine($"Total Tweets      : {stats.TotalTweets}");
			//Console.WriteLine($"Tweets/Second     : {(stats.TotalTweets / interval.TotalSeconds).ToString("F", CultureInfo.InvariantCulture)}");
			Console.WriteLine($"Tweets/Second     : {TweetsPerSecond(interval.TotalSeconds, stats.TotalTweets)}");
			Console.WriteLine($"Tweets/Minute     : {TweetsPerMinute(interval.TotalMinutes, stats.TotalTweets)}");
			Console.WriteLine($"Tweets/Hour       : {TweetsPerHour(interval.TotalHours, stats.TotalTweets)}");
			Console.WriteLine($"Tweets with Emojis: {underConstruction}%");
			Console.WriteLine($"Top Emojis        : {underConstruction}");
			Console.WriteLine($"Tweets with Url   : {TweetsHttpPercentage(stats.TotalTweets, stats.HttpTweets)}%");
			Console.WriteLine($"Top Urls          : {underConstruction}%");

			Console.WriteLine(" < ---------------- > ");
		}

		public void RenderText(string text)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(text);

			Console.WriteLine($"Sample Text > {text}");

			Console.WriteLine($"            > {Encoding.UTF8.GetString(bytes, 0, bytes.Length)}");
		}

		#endregion

		#region Private Methods

		private static string TweetsPerSecond(double seconds, long tweets)
		{
			if (seconds > 0)
				return (tweets / seconds).ToString("F", CultureInfo.InvariantCulture);
			else
				return tweets.ToString("F", CultureInfo.InvariantCulture);
		}

		private static string TweetsPerMinute(double minutes, long tweets)
		{
			if (minutes > 0)
				return Convert.ToInt64(tweets / minutes).ToString("F", CultureInfo.InvariantCulture);
			else
				return tweets.ToString("F", CultureInfo.InvariantCulture);
		}

		private static string TweetsPerHour(double hours, long tweets)
		{
			if (hours > 0)
				return Convert.ToInt64(tweets / hours).ToString("F", CultureInfo.InvariantCulture);
			else
				return tweets.ToString("F", CultureInfo.InvariantCulture);
		}

		private static long TweetsHttpPercentage(long tweets, long httpTweets)
		{
			if (httpTweets > 0)
				return tweets / httpTweets;
			else
				return 0;
		}

		#endregion
	}
}

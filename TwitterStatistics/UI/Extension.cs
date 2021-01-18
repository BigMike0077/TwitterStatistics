using System;
using System.Text;

namespace TwitterStatistics.UI
{
	public static class Extension
	{
		public static string ToUnicodeString(this string str)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var c in str)
			{
				sb.Append("\\u" + ((int)c).ToString("X4"));
			}
			return sb.ToString();
		}
	}
}

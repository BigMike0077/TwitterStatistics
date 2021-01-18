using System;
using TwitterStatistics.Models;

namespace TwitterStatistics.UI
{
	public interface IPage
	{
		void Init();
		void RenderStatistics(Statistics stats);
		void RenderText(string text);
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using EmojiData.Models;

namespace EmojiData
{
	public class EmojiProcessor
	{
		private IDictionary<string, Emoji> _emojis;
		public IDictionary<string, Emoji> EmojiMap
		{
			get
			{
				if (_emojis == null)
				{
					Emoji[] emojis;
					Assembly assembly = Assembly.GetAssembly(typeof(Emoji));
					string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("emojidata.json"));

					using (Stream stream = assembly.GetManifestResourceStream(resourceName))
					{
						using StreamReader reader = new StreamReader(stream);
						string json = reader.ReadToEnd();
						emojis = JsonSerializer.Deserialize<Emoji[]>(json);
					}
					if (emojis != null)
					{
						_emojis = emojis.Where(emoji => emoji.non_qualified != null).ToDictionary(emoji => emoji.non_qualified ?? emoji.unified);
					}
				}
				return _emojis;
			}
		}

		public Emoji[] FingEmojis(string text)
		{
			if (EmojiMap.ContainsKey(text))
			{ }
			return new Emoji[1];
		}
	}
}

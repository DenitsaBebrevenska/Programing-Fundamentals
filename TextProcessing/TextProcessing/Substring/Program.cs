﻿namespace Substring
{
	internal class Program
	{
		static void Main()
		{
			string wordToRemove = Console.ReadLine();
			string text = Console.ReadLine();

			while (text.Contains(wordToRemove))
			{
				text = text.Remove(text.IndexOf(wordToRemove), wordToRemove.Length);
			}

			Console.WriteLine(text);
		}
	}
}
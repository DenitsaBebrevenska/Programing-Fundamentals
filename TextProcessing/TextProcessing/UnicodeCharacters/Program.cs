namespace UnicodeCharacters
{
	internal class Program
	{
		static void Main()
		{
			string text = Console.ReadLine();
			List<string> convertedStrings = new List<string>();

			for (int i = 0; i < text.Length; i++)
			{
				convertedStrings.Add(@$"\u{(int)text[i]:x4}");
			}

			Console.WriteLine(string.Join("",convertedStrings));
		}
	}
}

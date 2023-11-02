using System.Text.RegularExpressions;

namespace MatchDates
{
	internal class Program
	{
		static void Main()
		{
			string dates = Console.ReadLine();
			string regexDate = @"\b(?<day>\d{2})(/|-|.)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

			MatchCollection dateCollection = Regex.Matches(dates, regexDate);

			foreach (Match date in dateCollection)
			{
				Console.WriteLine($"Day: {date.Groups["day"].Value}, Month: {date.Groups["month"].Value}," +
				                  $" Year: {date.Groups["year"].Value}");
			}
		}
	}
}
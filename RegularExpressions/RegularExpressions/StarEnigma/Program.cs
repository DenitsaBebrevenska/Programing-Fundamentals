using System.Text.RegularExpressions;

namespace StarEnigma
{
	internal class Program
	{
		static void Main()
		{ // 70/100 
			int numberOfMessages = int.Parse(Console.ReadLine());
			Dictionary<string, string> invasionMap = new Dictionary<string, string>();

			for (int i = 0; i < numberOfMessages; i++)
			{
				string currentMessage = Console.ReadLine();
				string planet = GetToken(currentMessage, @"@([A-Za-z]+)");
				string population = GetToken(currentMessage, @":(\d+)");
				string action = GetToken(currentMessage, @"!(A|D)!");
				string soldiers = GetToken(currentMessage, @"->(\d+)");

				if (planet == string.Empty || population == string.Empty ||
				    action == string.Empty || soldiers == string.Empty)
				{
					continue;
				}

				invasionMap.Add(planet, action);
			}

			PrintAttackedPlanets(invasionMap);
			PrintDestroyedPlanets(invasionMap);
		}

		static void PrintAttackedPlanets(Dictionary<string, string> invasionMap)
		{
			Console.WriteLine($"Attacked planets: {invasionMap.Count(x => x.Value == "A")}");
			foreach (var kvp in invasionMap.Where(x => x.Value == "A").OrderBy(x => x.Key))
			{
				Console.WriteLine($"-> {kvp.Key}");
			}
		}

		static void PrintDestroyedPlanets(Dictionary<string, string> invasionMap)
		{
			Console.WriteLine($"Destroyed planets: {invasionMap.Count(x => x.Value == "D")}");
			foreach (var kvp in invasionMap.Where(x => x.Value == "D").OrderBy(x => x.Key))
			{
				Console.WriteLine($"-> {kvp.Key}");
			}
		}

		static int GetLetterCount(string currentMessage)
		{
			int count = 0;
			currentMessage = currentMessage.ToLower();
			for (int i = 0; i < currentMessage.Length; i++)
			{
				if (currentMessage[i] == 's' || currentMessage[i] == 't' ||
					currentMessage[i] == 'a' || currentMessage[i] == 'r')
				{
					count++;
				}
			}
			return count;
		}
		static string DecryptMessage(string currentMessage)
		{
			string decryptedMessage = string.Empty;
			int count = GetLetterCount(currentMessage);

			foreach (char symbol in currentMessage)
			{
				decryptedMessage += (char)(symbol - count);
			}
			return decryptedMessage;
		}

		static string GetToken(string currentMessage, string filter)
		{
			string decryptedMessage = DecryptMessage(currentMessage);
			Match match = Regex.Match(decryptedMessage, filter);
			return match.Groups[1].Value; //returns {} if no groups
		}
	}
}
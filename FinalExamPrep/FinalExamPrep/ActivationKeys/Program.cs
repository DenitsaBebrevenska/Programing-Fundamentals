namespace ActivationKeys
{
	internal class Program
	{
		static void Main()
		{
			string rawKey = Console.ReadLine();
			string command;

			while ((command = Console.ReadLine()) != "Generate")
			{
				string[] commandDetails = command.Split(">>>");
				switch (commandDetails[0])
				{
					case "Contains":
						string substring = commandDetails[1];
						if (rawKey.Contains(substring))
						{
							Console.WriteLine($"{rawKey} contains {substring}");
						}
						else
						{
							Console.WriteLine("Substring not found!");
						}
						continue;
						break;
					case "Flip":
						string change = commandDetails[1];
						int startIndex = int.Parse(commandDetails[2]);
						int endIndex = int.Parse(commandDetails[3]);
						string extractedSubstring = rawKey.Substring(startIndex, endIndex - startIndex);
						if (change == "Upper")
						{
							extractedSubstring = extractedSubstring.ToUpper();
						}
						else
						{
							extractedSubstring = extractedSubstring.ToLower();
						}

						rawKey = rawKey.Remove(startIndex, endIndex - startIndex);
						rawKey = rawKey.Insert(startIndex, extractedSubstring);
						break;
					case "Slice":
						int startingIndex = int.Parse(commandDetails[1]);
						int endingIndex = int.Parse(commandDetails[2]);
						rawKey = rawKey.Remove(startingIndex, endingIndex - startingIndex);
						break;
				}

				Console.WriteLine(rawKey);
			}

			Console.WriteLine($"Your activation key is: {rawKey}");
		}
	}
}
using System.Globalization;

namespace SoftUniCoursePlanning
{
	internal class Program
	{
		static void Main()
		{
			List<string> schedule = Console.ReadLine().
				Split(", ").
				ToList();

			string action;
			while ((action = Console.ReadLine()) != "course start")
			{
				string[] tokens = action.Split(':');

				if (tokens[0] == "Add" && !schedule.Contains(tokens[1]))
				{
					schedule.Add(tokens[1]);
				}
				else if (tokens[0] == "Insert" && !schedule.Contains(tokens[1]))
				{
					schedule.Insert(int.Parse(tokens[2]), tokens[1]);
				}
				else if (tokens[0] == "Remove" && schedule.Contains(tokens[1]))
				{
					schedule.Remove(tokens[1]);
					string exerciseName = $"{tokens[1]}-Exercise";
					if (schedule.Contains(exerciseName))
					{
						schedule.Remove(exerciseName);
					}
				}
				else if (tokens[0] == "Swap" && schedule.Contains(tokens[1]) && schedule.Contains(tokens[2]))
				{
					for (int i = 0; i < schedule.Count; i++)
					{
						if (schedule[i] == tokens[1])
						{
							schedule[i] = tokens[2];
						}
						else if (schedule[i] == tokens[2])
						{
							schedule[i] = tokens[1];
						}
					}
					if (schedule.Contains($"{tokens[1]}-Exercise"))
					{
						schedule.Remove($"{tokens[1]}-Exercise");
						schedule.Insert(schedule.IndexOf(tokens[1]) + 1, $"{tokens[1]}-Exercise");
					}
					else if (schedule.Contains($"{tokens[2]}-Exercise"))
					{
						schedule.Remove($"{tokens[2]}-Exercise");
						schedule.Insert(schedule.IndexOf(tokens[2]) + 1, $"{tokens[2]}-Exercise");
					}
				}
				else if (tokens[0] == "Exercise")
				{
					string exerciseName = $"{tokens[1]}-Exercise";
					if (schedule.Contains(tokens[1]) && !schedule.Contains(exerciseName))
					{
						int indexLesson = schedule.IndexOf(tokens[1]);
						schedule.Insert(++indexLesson, exerciseName);
					}
					else if (!schedule.Contains(tokens[1]))
					{
						schedule.Add(tokens[1]);
						schedule.Add(exerciseName);
					}

				}
			}

			for (int i = 0; i < schedule.Count; i++)
			{
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
		}
	}
}
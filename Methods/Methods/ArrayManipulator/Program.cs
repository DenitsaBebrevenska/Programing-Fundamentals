using System.Diagnostics.Metrics;

namespace ArrayManipulator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// it is 50 /100 and needs tons of improving
			int[] initialArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int arrayLenght = initialArray.Length;
			string manipulation;
			while ((manipulation = Console.ReadLine()) != "end")
			{
				if (manipulation.Contains("exchange"))
				{
					string[] command = SplitCommand(manipulation);
					int index = Convert.ToInt32(command[1]);
					if (index >= 0 && index <= initialArray.Length - 1)
					{
						initialArray = ExchangePositions(index, initialArray);
					}
					else
					{
						Console.WriteLine("Invalid index");
						continue;
					}
				}
				else if (manipulation.Contains("max"))
				{
					string[] command = SplitCommand(manipulation);
					string evenOrOdd = command[1];
					if (evenOrOdd == "even")
					{
						int maxIndex = GetMaxEven(initialArray);
						if (maxIndex >= 0)
						{
							Console.WriteLine(maxIndex);
						}
						else
						{
							Console.WriteLine("No matches");
						}
					}
					else
					{
						int maxIndex = GetMaxOdd(initialArray);
						if (maxIndex >= 0)
						{
							Console.WriteLine(maxIndex);
						}
						else
						{
							Console.WriteLine("No matches");
						}
					}
				}
				else if (manipulation.Contains("min"))
				{
					string[] command = SplitCommand(manipulation);
					string evenOrOdd = command[1];
					if (evenOrOdd == "even")
					{
						int minIndex = GetMinEven(initialArray);
						if (minIndex >= 0)
						{
							Console.WriteLine(minIndex);
						}
						else
						{
							Console.WriteLine("No matches");
						}
					}
					else
					{
						int minIndex = GetMinOdd(initialArray);
						if (minIndex >= 0)
						{
							Console.WriteLine(minIndex);
						}
						else
						{
							Console.WriteLine("No matches");
						}
					}
				}
				else if (manipulation.Contains("first"))
				{
					string[] command = SplitCommand(manipulation);
					int count = Convert.ToInt32(command[1]);
					string evenOrOdd = command[2];
					if (count > initialArray.Length)
					{
						Console.WriteLine("Invalid count");
						continue;
					}
					if (evenOrOdd == "even")
					{
						string printMessage = GetFirstEven(initialArray, count);
						Console.WriteLine($"[{printMessage}]");
					}
					else
					{
						string printMessage = GetFirstOdd(initialArray, count);
						Console.WriteLine($"[{printMessage}]");
					}
				}
				else if (manipulation.Contains("last"))
				{
					string[] command = SplitCommand(manipulation);
					int count = Convert.ToInt32(command[1]);
					string evenOrOdd = command[2];
					if (count > initialArray.Length)
					{
						Console.WriteLine("Invalid count");
						continue;
					}
					if (evenOrOdd == "even")
					{
						string printMessage = GetLastEven(initialArray, count);
						Console.WriteLine($"[{printMessage}]");
					}
					else
					{
						string printMessage = GetLastOdd(initialArray, count);
						Console.WriteLine($"[{printMessage}]");
					}
				}
			}

			string printFinalArray = string.Join(", ", initialArray);
			Console.WriteLine($"[{printFinalArray}]");
		}

		static string[] SplitCommand(string manipulation)
		{
			string[] commandSplit = manipulation.Split(" ").ToArray();
			return commandSplit;
		}

		static int[] ExchangePositions(int index, int[] initialArray)
		{
			int[] firstArray = new int[index + 1];
			int[] secondArray = new int[initialArray.Length - (index + 1)];
			for (int i = 0; i <= index; i++)
			{
				firstArray[i] = initialArray[i];
			}

			int lastIndex = initialArray.Length - 1;
			int j = 0;
			for (int i = index + 1; i <= lastIndex; i++)
			{
				secondArray[j] = initialArray[i];
				j++;
			}

			int[] newArray = secondArray.Concat(firstArray).ToArray();
			return newArray;
		}

		static int GetMaxEven(int[] initialArray)
		{
			int maxEvenIndex = 0;
			int maxInt = int.MinValue;
			for (int i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] % 2 == 0)
				{
					if (initialArray[i] >= maxInt)
					{
						maxInt = initialArray[i];
						maxEvenIndex = i;
					}
				}
			}

			if (maxInt > int.MinValue)
			{
				return maxEvenIndex;
			}
			else
			{
				return -1;
			}
		}
		static int GetMaxOdd(int[] initialArray)
		{
			int maxOddIndex = 0;
			int maxInt = int.MinValue;
			for (int i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] % 2 != 0)
				{
					if (initialArray[i] >= maxInt)
					{
						maxInt = initialArray[i];
						maxOddIndex = i;
					}
				}
			}

			if (maxInt > int.MinValue)
			{
				return maxOddIndex;
			}
			else
			{
				return -1;
			}
		}
		static int GetMinEven(int[] initialArray)
		{
			int minEvenIndex = 0;
			int minInt = int.MaxValue;
			for (int i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] % 2 == 0)
				{
					if (initialArray[i] <= minInt)
					{
						minInt = initialArray[i];
						minEvenIndex = i;
					}
				}
			}

			if (minInt < int.MaxValue)
			{
				return minEvenIndex;
			}
			else
			{
				return -1;
			}
		}
		static int GetMinOdd(int[] initialArray)
		{
			int minOddIndex = 0;
			int minInt = int.MaxValue;
			for (int i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] % 2 != 0)
				{
					if (initialArray[i] <= minInt)
					{
						minInt = initialArray[i];
						minOddIndex = i;
					}
				}
			}

			if (minInt < int.MaxValue)
			{
				return minOddIndex;
			}
			else
			{
				return -1;
			}
		}

		static string GetFirstEven(int[] initialArray, int count)
		{
			string numbers = string.Empty;
			for (int i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] % 2 == 0)
				{
					numbers += initialArray[i] + ", ";
					count--;
					if (count == 0)
					{
						break;
					}
				}
			}

			numbers = numbers.Trim();
			return numbers.TrimEnd(',');
		}
		static string GetFirstOdd(int[] initialArray, int count)
		{
			string numbers = string.Empty;
			for (int i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] % 2 != 0)
				{
					numbers += initialArray[i] + ", ";
					count--;
					if (count == 0)
					{
						break;
					}
				}
			}
			numbers = numbers.Trim();
			return numbers.TrimEnd(',');
		}

		static string GetLastEven(int[] initialArray, int count)
		{
			string numbers = string.Empty;
			for (int i = initialArray.Length - 1; i >= 0; i--)
			{
				if (initialArray[i] % 2 == 0)
				{
					numbers += initialArray[i] + " ";
					count--;
					if (count == 0)
					{
						break;
					}
				}
			}
			numbers = numbers.Trim();
			string reversedString = new string(numbers.Reverse().ToArray());
			string replacedString = reversedString.Replace(" ", ", ");
			return replacedString;
		}
		static string GetLastOdd(int[] initialArray, int count)
		{
			string numbers = string.Empty;
			for (int i = initialArray.Length - 1; i >= 0; i--)
			{
				if (initialArray[i] % 2 != 0)
				{
					numbers += initialArray[i] + " ";
					count--;
					if (count == 0)
					{
						break;
					}
				}
			}
			numbers = numbers.Trim();
			string reversedString = new string(numbers.Reverse().ToArray());
			string replacedString = reversedString.Replace(" ", ", ");
			return replacedString;
		}
	}
}
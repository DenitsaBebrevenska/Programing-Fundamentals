using System.Linq;
using System.Text.RegularExpressions;

namespace KaminoFactory
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int sequenceLenght = int.Parse(Console.ReadLine());
			string input = Console.ReadLine();
			int longestSequence = 1, linesCount = 0, bestLineNumber = 0, bestStartingIndex = 0, bestStartingIndexAllLines = 0,
				bestSequenceSum = 0;
			int[] bestSequence = new int[sequenceLenght];
			
			while (input != "Clone them!") 
			{
				int[] currentLine = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); 
																  
				int currentLineIndex = 0, currentLineMaxSequence = 1;
			    int currentSequence = 1;
				int currentLineSum = currentLine.Sum();
				linesCount++;
				for (int i = 0; i < currentLine.Length - 1; i++) //sequence finder
				{
					if (currentLine[i] == 1) 
					{
						if (currentLine[i] == currentLine[i + 1])
						{
							if (currentSequence == 1) //save the starting index
							{
								currentLineIndex = i;
							}
							currentSequence++;
						}        //this is end of sequence 
						else if (currentLine[i] != currentLine[i+1])
						{
							if (currentSequence > currentLineMaxSequence)
							{
								currentLineMaxSequence = currentSequence;
								bestStartingIndex = currentLineIndex;
								currentSequence = 1;
							}
						}
					}
				}
				if (currentLineMaxSequence > longestSequence) //check max sequence thus far for all lines
				{
					longestSequence = currentLineMaxSequence;
					bestSequence = currentLine;
					bestStartingIndexAllLines = bestStartingIndex;
					bestSequenceSum = currentLineSum;
					bestLineNumber = linesCount;
					
				}
				else if (currentLineMaxSequence == longestSequence) // if equal sequences, left most starting index wins
				{
					if (bestStartingIndex < bestStartingIndexAllLines)
					{
						bestSequence = currentLine;
						bestStartingIndexAllLines = bestStartingIndex;
						bestSequenceSum = currentLineSum;
						bestLineNumber = linesCount;
					}
					else if (bestStartingIndex == bestStartingIndexAllLines) //if same starting index
					{
						if (currentLineSum > bestSequenceSum) //bigger sum of the two wins
						{
							bestSequenceSum = currentLineSum;
							bestSequence = currentLine;
							bestLineNumber = linesCount;
						}
					} 
				}
				input = Console.ReadLine();
			}
			string output = string.Join(" ", bestSequence);
			Console.WriteLine($"Best DNA sample {bestLineNumber} with sum: {bestSequenceSum}.");
			Console.WriteLine(output);
		}
	}
}
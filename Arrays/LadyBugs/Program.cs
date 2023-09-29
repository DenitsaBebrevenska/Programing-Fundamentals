using System.Runtime.CompilerServices;

namespace LadyBugs
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int fieldSize = int.Parse(Console.ReadLine());
			int[] startingLocations = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			string move = Console.ReadLine();
			int[] board = new int[fieldSize];
			for (int i = 0; i < startingLocations.Length; i++) //populate the initial board with 1 and 0
			{
				if (startingLocations[i] >= 0 && startingLocations[i] < fieldSize) //some indexes could be outside of board so...
				{ board[startingLocations[i]] = 1; }
			}
			while (move != "end")
			{
				string[] moveDetails = move.Split(' ');
				int ladybugIndex = int.Parse(moveDetails[0]);
				int flyLenght = int.Parse(moveDetails[2]);
				string direction = moveDetails[1];
				int currentPosition = ladybugIndex;
				//check initial insructions = not outside of board and if there is a bug to move there, otherwise read next move
				if (ladybugIndex >= 0 && ladybugIndex <= fieldSize - 1 && board[ladybugIndex] == 1)
				{
					while (true)
					{
						if (direction == "left")
						{
							if (currentPosition - flyLenght >= 0) // next move will be on board
							{
								if (board[currentPosition - flyLenght] == 0) // moved left and  the spot is vacant
								{
									board[currentPosition] -= 1; //vacate the old spot
									currentPosition -= flyLenght; //calculate new index
									board[currentPosition] += 1; //position on new index
									break; //get new move instructions
								}
								else if (board[currentPosition - flyLenght] != 0) //moved left but spot is taken
								{
									board[currentPosition] -= 1; //vacate old spot
									currentPosition -= flyLenght; //calculate new index
									board[currentPosition] += 1; //stack the bugs
									continue; //keep moving
								}
							}
							else //flies off
							{
								board[currentPosition] -= 1; //remove one bug
								break;
							}
						}
						else if (direction == "right")
						{
							if (currentPosition + flyLenght <= fieldSize - 1)
							{
								if (board[currentPosition + flyLenght] == 0) // moved left and  the spot is vacant
								{
									board[currentPosition] -= 1; //vacate the old spot
									currentPosition += flyLenght; //calculate new index
									board[currentPosition] += 1; //position on new index
									break; //get new move instructions
								}
								else if (board[currentPosition + flyLenght] != 0) //moved left but spot is taken
								{
									board[currentPosition] -= 1; //vacate old spot
									currentPosition += flyLenght; //calculate new index
									board[currentPosition] += 1; //stack the bugs
									continue; //keep moving
								}
							}
							else //flies off
							{
								board[currentPosition] -= 1; //remove one bug
								break;
							}
						}
					}

				}
				
				move = Console.ReadLine();
			}
			Console.WriteLine(string.Join(" ", board)); 
		}
	}
}
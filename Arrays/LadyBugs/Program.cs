namespace LadyBugs
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int fieldSize = int.Parse(Console.ReadLine());
			int[] startingLocations = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			string move = Console.ReadLine();

			//move = {ladybug index} {direction} {fly length}, so basically a string with int blank right/left blank int
			//can go left or right
			//if ladybug lands on another ladybug, it continues to fly in the same direction with the same flight lenght
			//if ladybug flies off the playing field, it is gone
			//if the input index contains no ladybug, nothing happens
			//if the input index is outside of the field, nothing happens
			// [1] [1] [0]
			// 0    1   2
			int[] board = new int[fieldSize];
			for (int i = 0; i < startingLocations.Length; i++) //populate the initial board with 1 and 0
			{
				board[startingLocations[i]] = 1;
			}
			while (move != "end")
			{
				string[] moveDetails = move.Split(' ');
				int ladybugIndex = int.Parse(moveDetails[0]);
				int flyLenght = int.Parse(moveDetails[2]);
				string direction = moveDetails[1];
				int currentPosition = ladybugIndex;
				//first I need to check the ladybugIndex, main concern not to go out of bounds
				if (ladybugIndex >= 0 && ladybugIndex <= fieldSize - 1) //it is valid index, not outside of board
				{
					while (currentPosition - flyLenght >= 0 && currentPosition + flyLenght <= fieldSize - 1)
					{   // moved left and  the spot is vacant
						if (direction == "left" && board[currentPosition - flyLenght] == 0)
						{
							board[currentPosition] = 0; //vacate the old spot
							currentPosition -= flyLenght; //calculate new index
							board[currentPosition] = 1; //position on new index
						}
						else if (direction == "left" && board[currentPosition - flyLenght] == 1)
					}	
				}

			}
			Console.WriteLine(string.Join(" ", board));
		


		}
	}
}
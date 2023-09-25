namespace RockPaperScissors
{
	internal class RockPaperScissors
	{
		const string Rock = "Rock";
		const string Paper = "Paper";
		const string Scissors = "Scissors";
		static bool restart = true;
		static void Main(string[] args)
		{
			while (restart)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("It`s time to play Rock Paper Scissors!");
				Console.Write("Make a choice: [r]ock, [p]aper or [s]cissors:");

				string userInput = Console.ReadLine();
				bool userInputCorrect = CheckUserInput(userInput).success;
				string userChoice = CheckUserInput(userInput).userChoice;
				if (userInputCorrect == false)
				{
					while (userInputCorrect == false)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Invalid input! Try again!");
						Console.WriteLine("Make your choice again: [r]ock, [p]aper or [s]cissors:");
						userInput = Console.ReadLine();
						userInputCorrect = CheckUserInput(userInput).success;
					}
					userChoice = CheckUserInput(userInput).userChoice;
				}
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"You chose: {userChoice}");

				string computerMove = GenerateComputerMove();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine($"The computer chose: {computerMove}");
				CheckMoves(userChoice, computerMove);
				RestartOrEndGame();
			}

        }
		static (bool success, string userChoice) CheckUserInput(string userInput)
		{
			if (userInput == "r" || userInput == "R")
			{
				return (true, Rock);
			}
			else if (userInput == "p" || userInput == "P")
			{
				return (true, Paper);
			}
			else if (userInput == "s" || userInput == "S")
			{
				return (true, Scissors);
			}
			else
			{
				return (false, "");
			}
		}
		static string GenerateComputerMove()
		{
			Random random = new Random();
			int computerRandomNumber = random.Next(1, 4);
			if (computerRandomNumber == 1)
			{
				return Rock;
			}
			else if (computerRandomNumber == 2)
			{
				return Paper;
			}
			else
			{ 
				return Scissors;
			}
		}
		static void CheckMoves(string userChoice, string computerMove)
		{
			if ((userChoice == Rock && computerMove == Scissors) ||
				(userChoice == Paper && computerMove == Rock) ||
				(userChoice == Scissors) && computerMove == Paper)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("You win!");
			}
			else if ((userChoice == Scissors && computerMove == Rock) ||
				(userChoice == Rock && computerMove == Paper) ||
				(userChoice == Paper && computerMove == Scissors))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("You lose!");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("It`s a draw!");
			}
		}
		static void RestartOrEndGame()
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine("Do you wish to continue?");
			Console.WriteLine("Press any key to restart the game or press [q] to quit: ");
			var keyPressed = Console.ReadKey();
			if (keyPressed.KeyChar == 'q' || keyPressed.KeyChar == 'Q')
			{
				restart = false;
			}
			else 
			{
				Console.Clear();
			}
		}
	}
}
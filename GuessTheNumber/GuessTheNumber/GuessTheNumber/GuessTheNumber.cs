using System.Threading.Channels;

namespace GuessTheNumber
{
	internal class GuessTheNumber
	{
		static bool _restart = true;

		static void Main(string[] args)
		{
			while (_restart)
			{
				Introduction();
				int numberToGuess = GenerateRandomNumber();
				Console.WriteLine("Make your guess:");
				int playerAttempts = 0;
				while (true)
				{
					int playerGuess = CheckPlayerInput();

					if (playerGuess == numberToGuess)
					{
						Console.WriteLine("Congratulations!");
						Console.WriteLine("YOU WIN!");
						break;
					}
					else if (playerGuess > numberToGuess)
					{
						Console.WriteLine(playerGuess - numberToGuess <= 5
							? "High, but you are really close!"
							: "Too high! Make another guess: ");
						playerAttempts = IncrementAttempts(playerAttempts);
						Console.WriteLine();
					}
					else if (playerGuess < numberToGuess)
					{
						Console.WriteLine(numberToGuess - playerGuess <= 5
							? "Low, but you are really close!"
							: "Too low! Make another guess: ");
						playerAttempts = IncrementAttempts(playerAttempts);
						Console.WriteLine();
					}

					if (AttemptsOver(playerAttempts))
					{
						Console.WriteLine("You ran out of guess attempts!");
						Console.WriteLine("YOU LOSE!");
						break;
					}
				}
				OfferRestartOrEnd();
			}
		}

		static void Introduction()
		{
			Console.WriteLine("Let`s play a game of Guess The number!");
			Console.WriteLine("The computer is picking a number between 1 and 100 inclusive...");
			SimulateThinking();
			Console.WriteLine("Time to guess!");
			Console.WriteLine("Beware! You have 10 attempts to find the answer or you`ll lose!");
			Console.WriteLine("Press any key to start the game: ");
			Console.ReadKey();
			Console.Clear();
		}
		static int GenerateRandomNumber()
		{
			Random randomNumber = new Random();
			int numberToGuess = randomNumber.Next(1, 101);
			return numberToGuess;
		}
		static void SimulateThinking()
		{
			for (int i = 0; i < 3; i++)
			{
				Console.Write(". ");
				System.Threading.Thread.Sleep(600);
			}

			Console.WriteLine();
		}

		static void OfferRestartOrEnd()
		{
			Console.WriteLine("You can restart the game by pressing any key!");
			Console.WriteLine("Or press ESC to exit the game!");
			Console.WriteLine("Restart or exit ?");
			var keyPressed = Console.ReadKey();
			if (keyPressed.KeyChar == 27)
			{
				_restart = false;
			}
			else
			{
				Console.Clear();
			}
		}

		static int CheckPlayerInput()
		{
			while (true)
			{
				string input = Console.ReadLine();
				int playerGuess;

				try
				{
					playerGuess = int.Parse(input);
				}
				catch (Exception)
				{
					Console.WriteLine("Your input is invalid!");
					Console.WriteLine("Enter a number between 1 and 100 inclusive:");
					Console.WriteLine();
					continue;
				}

				if (playerGuess  is <= 0 or > 100)
				{
					Console.WriteLine("Invalid number!");
					Console.WriteLine("Enter a number between 1 and 100 inclusive:");
					Console.WriteLine();
					continue;
				}

				return playerGuess;
			}
		}

		static int IncrementAttempts(int attempts)
		{
			Console.WriteLine($"Attempts to guess: {++attempts}/ 10!");
			return attempts;

		}

		static bool AttemptsOver(int attempts)
		{
			return attempts >= 10;
		}
	}
}
namespace GuessTheNumber
{
	internal class GuessTheNumber
	{

		static void Main(string[] args)
		{
			Introduction();
			int numberToGuess = GenerateRandomNumber();
			Console.WriteLine("Make your guess:");

			while (true)
			{
				string input = Console.ReadLine();
				int playerGuess = 0;
				try
				{
					playerGuess = int.Parse(input);
				}
				catch (Exception)
				{
                    Console.WriteLine("You input is invalid!");
                    Console.WriteLine("Enter a number between 1 and 100 inclive:");
					continue;
                }

				if (playerGuess == numberToGuess)
				{
					Console.WriteLine("Congratulations! You won!");
					break;
				}
				else if (playerGuess > numberToGuess)
				{
					Console.WriteLine("Too high! Make another guess: ");
				}
				else if (playerGuess < numberToGuess)
				{
                    Console.WriteLine("Too low! Make another guess: ");
                }
			}
		}
		static void Introduction()
		{
			Console.WriteLine("Let`s play a game of Guess The number!");
			Console.WriteLine("The computer is picking a number between 1 and 100 inclusive...");
			//add timer
			
			Console.WriteLine("Time to guess!");
			Console.WriteLine("Beware though you have 30 seconds to find the answer or you`ll lose!"); //timer or attempts?
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
	}
}
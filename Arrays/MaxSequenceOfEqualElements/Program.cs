namespace MaxSequenceOfEqualElements
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			//0 1 2 3 4 5 6 7
			//1 1 1 2 3 1 3 3
		
			for (int i = 0; i < numbers.Length - 1; i++) //don`t check the last number, can`t start a sequence there
			{ //tho I dont need to loop through numbers if they are already part of a sequence
				
				for (int k = 1; k < numbers.Length - 1; k++)
				{
					if (numbers[i] == numbers[i + k])
					{

					}
					else { }

				}
				
			}
		}
	}
}
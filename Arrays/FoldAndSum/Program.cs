namespace FoldAndSum
{
	internal class Program
	{
		static void Main()
		{
			//numbers as central bottom array
			//left and right upper have each central / 2 length;
			// [ 0 1 2 3 4 5 6 7] - 8 length, central piece has 4 length, the other to - 2 each
			// [ 1 2 3 4 5 6 7 8]
			int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int[] bottomArray = new int[numbers.Length / 2];
			int[] leftArray = new int[bottomArray.Length /2];
			int[] rightArray = new int[bottomArray.Length /2];
			int indexStart = leftArray.Length;
			int indexEnd = numbers.Length - leftArray.Length;
			int j = 0;
			for (int i = indexStart; i <= indexEnd; i++, j++) //populate the bottom array
			{
				bottomArray[j] = numbers[i];
			}
		}
	}
}
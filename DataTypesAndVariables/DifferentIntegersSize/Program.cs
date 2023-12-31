﻿namespace DifferentIntegersSize
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			long number;

			if (long.TryParse(input, out number))
			{
				Console.WriteLine($"{number} can fit in:");

				if (number >= sbyte.MinValue && number <= sbyte.MaxValue)
					Console.WriteLine("* sbyte");
				if (number >= byte.MinValue && number <= byte.MaxValue)
					Console.WriteLine("* byte");
				if (number >= short.MinValue && number <= short.MaxValue)
					Console.WriteLine("* short");
				if (number >= ushort.MinValue && number <= ushort.MaxValue)
					Console.WriteLine("* ushort");
				if (number >= int.MinValue && number <= int.MaxValue)
					Console.WriteLine("* int");
				if (number >= uint.MinValue && number <= uint.MaxValue)
					Console.WriteLine("* uint");
				if (number >= long.MinValue && number <= long.MaxValue)
					Console.WriteLine("* long");
			}
			else
			{
				Console.WriteLine($"{input} can't fit in any type");
			}
		}
	}
}
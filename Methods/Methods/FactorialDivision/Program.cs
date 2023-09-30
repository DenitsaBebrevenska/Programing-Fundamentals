namespace FactorialDivision
{
	internal class Program
	{
		static void Main()
		{
			long number1 = long.Parse(Console.ReadLine());
			long number2 = long.Parse(Console.ReadLine());
			decimal resultDivision = Divide(number1, number2);
			Console.WriteLine($"{resultDivision:f2}");
		}

		static long CalculateFactorial(long number)
		{
			long factorial = 1;
			for (long i = 1; i <= number; i++)
			{
				factorial *= i;
			}
			return factorial;
		}

		static decimal Divide(long number1, long number2)
		{
			number1 = CalculateFactorial(number1);
			number2 = CalculateFactorial(number2);
			return (decimal)number1 / (decimal)number2;
		}
	}
}
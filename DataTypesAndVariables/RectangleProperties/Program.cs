﻿namespace RectangleProperties
{
	internal class Program
	{
		static void Main()
		{
			double width = double.Parse(Console.ReadLine());
			double height = double.Parse(Console.ReadLine());

			double perimeter = (width + height) * 2;
			double area = width * height;
			double diagonal = Math.Sqrt(Math.Pow(height,2) + Math.Pow(width,2));

			Console.WriteLine(perimeter);
			Console.WriteLine(area);
			Console.WriteLine(diagonal);
		}
	}
}
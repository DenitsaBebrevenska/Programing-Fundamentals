﻿namespace RectangleArea
{
	internal class Program
	{
		static void Main()
		{
			double width = double.Parse(Console.ReadLine());
			double height = double.Parse(Console.ReadLine());

			double area = width * height;
			Console.WriteLine($"{area:F2}");
		}
	}
}
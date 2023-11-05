using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
	internal class Program
	{
		static void Main()
		{
			string input;
			decimal totalIncome = 0;

			while ((input = Console.ReadLine()) != "end of shift")
			{
				string customerName = GetToken(input,@"%[A-Z][a-z]+%" );
				string product = GetToken(input,@"<\w+>");
				string quantity = GetToken(input, @"\|\d+\|");
				string price = GetToken(input,@"\d+\.*\d*\$");

				if (customerName == string.Empty || product == string.Empty ||
				    quantity == string.Empty || price == string.Empty)
				{
					continue;
				}
				

				customerName = customerName.Replace("%", "");
				product = product.Replace("<" , "").Replace(">","");
				quantity = quantity.Replace("|", "");
				int quantityNumber = int.Parse(quantity);
				price = price.Replace("$", "");
				decimal priceNumber = decimal.Parse(price);
				decimal totalClient = priceNumber * quantityNumber;
				totalIncome += totalClient;

				Console.WriteLine($"{customerName}: {product} - {totalClient:F2}");
			}

			Console.WriteLine($"Total income: {totalIncome:F2}");
		}

		private static string GetToken(string input, string filter)
		{
			Match match = Regex.Match(input, filter);
			return match.ToString();
		}
	}
}
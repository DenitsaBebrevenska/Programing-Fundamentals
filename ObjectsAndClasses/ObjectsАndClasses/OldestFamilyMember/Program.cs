namespace OldestFamilyMember
{
	internal class Program
	{
		static void Main()
		{
			int peopleCount = int.Parse(Console.ReadLine());
			Family family = new Family();
			for (int i = 0; i < peopleCount; i++)
			{
				string[] personDetails = Console.ReadLine().Split();
				string name = personDetails[0];
				int age = int.Parse(personDetails[1]);
				Family.AddPerson(new Person(name, age));
			}

			Person oldestPerson = Family.GetOldestPerson();
			Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
		}
	}

	internal class Person
	{
		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public string Name { get; set; }
		public int Age { get; set; }
	}

	internal class Family
	{
		public static List<Person> People;

		public Family()
		{
			People = new List<Person>();
		}
		public static void AddPerson(Person person)
		{
			People.Add(person);
		}

		public static Person GetOldestPerson()
		{
			Person oldestPerson = People.OrderByDescending(p => p.Age).First();
			return oldestPerson;
		}
	}
}
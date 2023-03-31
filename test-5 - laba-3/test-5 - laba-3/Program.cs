using test_5___laba_3;
using Newtonsoft.Json;
do
{
	Console.Clear();
	double x1, y1, x2, y2, x3, y3;
	if (TryInputValue("x1 = ", out x1) && TryInputValue("y1 = ", out y1))
	if (TryInputValue("x2 = ", out x2) && TryInputValue("y2 = ", out y2))
	if (TryInputValue("x3 = ", out x3) && TryInputValue("y3 = ", out y3))
	{
		Triangle triangle1 = new Triangle(x1, y1, x2, y2, x3, y3);
		SerializeAndDeserializeFromFile(triangle1);
		//Menu(triangle1);

	}
	Console.WriteLine("\n You want to complete the program: yes or no");
} while (!(string.Equals(Console.ReadLine(), "yes", StringComparison.OrdinalIgnoreCase)));


static void Menu(Triangle triangle1)
{
	int option;
	string answer;
	do
	{
		Console.Clear();
		Console.WriteLine("Виберiть опцiю:");
		Console.WriteLine("1. Чи рiвнi два трикутники?");
		Console.WriteLine("2. Площа трикутника");
		Console.WriteLine("3. Периметр трикутника");
		Console.WriteLine("4. Висоти трикутника");
		Console.WriteLine("5. Медiани трикутника");
		Console.WriteLine("6. Бiсектриси трикутника");
		Console.WriteLine("7. Радiус вписаного кола трикутника");
		Console.WriteLine("8. Радiус описаного кола трикутника");
		Console.WriteLine("9. Тип трикутника");
		Console.WriteLine("10. Поворот трикутника");
		while (true)
		{
			if (TryInputValueMenu("", out option))
			{
				if (option == 1)
					Equal(triangle1);
				if (option == 2)
				{
					Console.Clear();
					Console.WriteLine("Площа : " + triangle1.Area());
				}
				if (option == 3)
				{
					Console.Clear();
					Console.WriteLine("Периметр : " + triangle1.Perimeter());
				}
				if (option == 4)
					Heights(triangle1);
				if (option == 5)
					Medians(triangle1);
				if (option == 6)
					Bisectors(triangle1);
				if (option == 7)
				{
					Console.Clear();
					Console.WriteLine("Радiус вписаного кола трикутника: " + triangle1.InCircleRadius());
				}
				if (option == 8)
				{
					Console.Clear();
					Console.WriteLine("Радiус описаного кола трикутника: " + triangle1.CircumCircleRadius());
				}
				if (option == 9)
				{
					Console.Clear();
					Console.WriteLine("Тип трикутника: " + triangle1.Type());
				}
				if (option == 10)
					Rotate(triangle1);
			}
			Console.WriteLine();
			Console.WriteLine("Хочете побачити пункти меню? (yes/no) ");
			answer = Console.ReadLine();
			if (answer == "yes")
				break;
			else
			{
				answer = "no";
				Console.Clear();
				break;
			}
		}

	} while (answer != "no");
}

static bool TryInputValue(string argumentName, out double value)
{
	Console.Write($"{argumentName}");
	string stringValue = Console.ReadLine();
	if (double.TryParse(stringValue, out value))
	{
		return true;
	}
	Console.WriteLine($"You wrote incorrect value {stringValue}");
	return false;
}
static bool TryInputValueMenu(string argumentName, out int value)
{
	Console.Write($"{argumentName}");
	string stringValue = Console.ReadLine();
	if (int.TryParse(stringValue, out value))
	{
		if (value >= 1 && value <= 10)
		{
			return true;
		}
	}
	Console.WriteLine($"You wrote incorrect value {stringValue}");
	return false;
}
static bool TryInputValueMenuRotate(string argumentName, out int value)
{
	Console.Write($"{argumentName}");
	string stringValue = Console.ReadLine();
	if (int.TryParse(stringValue, out value))
	{
		if (value >= 1 && value <= 2)
		{
			return true;
		}
	}
	Console.WriteLine($"You wrote incorrect value {stringValue}");
	return false;
}


static void Equal(Triangle triangle1)
{
	Console.Clear();
	Random rnd = new Random();
	Triangle triangle2 = new Triangle(rnd.Next(-100, 101), rnd.Next(-100, 101), rnd.Next(-100, 101), rnd.Next(-100, 101), rnd.Next(-100, 101), rnd.Next(-100, 101));
	bool isEqual = triangle1.Equals(triangle2);
	Console.WriteLine("Чи рiвнi два трикутники? = " + isEqual);
}
static void Heights(Triangle triangle1)
{
	Console.Clear();
	double[] heights = triangle1.Heights();
	Console.WriteLine("h(A) \t h(B) \t h(C)");
	foreach (int i in heights)
	{
		Console.Write(i + "\t");
	}
}
static void Medians(Triangle triangle1)
{
	Console.Clear();
	double[] medians = triangle1.Medians();
	Console.WriteLine("m(A) \t m(B) \t m(C)");
	foreach (int i in medians)
	{
		Console.Write(i + "\t");
	}
}
static void Bisectors(Triangle triangle1)
{
	Console.Clear();
	double[] bisectors = triangle1.Bisectors();
	Console.WriteLine("b(A) \t b(B) \t b(C)");
	foreach (int i in bisectors)
	{
		Console.Write(i + "\t");
	}
}

static void Rotate(Triangle triangle1)
{
	do
	{
		Console.Clear();
		int n;
		Console.WriteLine("Поворот на заданий кут вiдносно: ");
		Console.WriteLine("1.Oднiєї з вершин");
		Console.WriteLine("2.Центру описаного кола");
		if (TryInputValueMenuRotate("", out n))
		{
			if (n == 1)
				RotationBehindTheVertex(triangle1);
			if (n == 2)
				RotationRelativeToTheCenterOfTheCircle(triangle1);
		}
		Console.WriteLine("Бажаєте повернутись у меню? (yes,no): ");
	} while (!(string.Equals(Console.ReadLine(), "yes", StringComparison.OrdinalIgnoreCase)));

}
//Метод для повороту на заданий кут відносно однієї з вершин
static void RotationBehindTheVertex(Triangle triangle1)
{
	Console.WriteLine("Triangle before rotation:");
	Console.WriteLine(triangle1);
	triangle1.Rotate(45, 1);
	Console.WriteLine("Triangle after rotating 45 degrees around vertex 1:");
	Console.WriteLine(triangle1);
}
//Метод для повороту на заданий кут відносно центру описаного кола
static void RotationRelativeToTheCenterOfTheCircle(Triangle triangle1)
{
	Console.WriteLine("Original triangle:");
	Console.WriteLine(triangle1);
	triangle1.Rotate(45);
	Console.WriteLine("Triangle rotated by 45 degrees:");
	Console.WriteLine(triangle1);
}

static void SerializeAndDeserializeFromFile(Triangle triangle1)
{
	string filePath = "E:\\Навчання\\tria.txt";

	// Збереження в JSON файл
	Triangle.SerializeToFile(triangle1, filePath);
	Console.WriteLine($"Triangle saved to {filePath}");

	// Відкриття JSON файлу та десеріалізація
	Triangle loadedTriangle = Triangle.DeserializeFromFile<Triangle>(filePath);

	// Порівняння збереженого трикутника та завантаженого трикутника
	if (triangle1.Equals(loadedTriangle))
	{
		Console.WriteLine("The saved and loaded triangles are equal.");
	}

	// Виведення серіалізованого трикутника
	Triangle.Print(triangle1);
}

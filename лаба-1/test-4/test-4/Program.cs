//Скласти опис класу для трикутника. Зберігає координати вершин трикутника на площині. 
//	Методи: чи рівні два трикутники, площа, периметр, висоти, медіани, бісектриси, 
//	радіус вписаного, радіус описаного кола, тип трикутника (рівносторонній,
//	рівнобедрений, прямокутний, гострокутний, тупокутний), поворот на заданий 
//	кут відносно (однієї з вершин, центру описаного кола).

using test_4;

while (true)
{
	double x1, y1, x2, y2, x3, y3;
	Console.WriteLine("Enter the coordinates of the triangle vertices:");
	Console.Write("x1 = ");
	x1 = double.Parse(Console.ReadLine());
	Console.Write("y1 = ");
	y1 = double.Parse(Console.ReadLine());
	Console.Write("x2 = ");
	x2 = double.Parse(Console.ReadLine());
	Console.Write("y2 = ");
	y2 = double.Parse(Console.ReadLine());
	Console.Write("x3 = ");
	x3 = double.Parse(Console.ReadLine());
	Console.Write("y3 = ");
	y3 = double.Parse(Console.ReadLine());

	Triangle triangle = new Triangle(x1, y1, x2, y2, x3, y3);

	int choice;
	do
	{
		Console.WriteLine("1. Calculate area");
		Console.WriteLine("2. Exit");
		Console.Write("Enter your choice: ");
		choice = int.Parse(Console.ReadLine());

		switch (choice)
		{
			case 1:
				Console.WriteLine("Area = " + triangle.Area());
				break;
			case 2:
				Console.WriteLine("Goodbye!");
				break;
			default:
				Console.WriteLine("Invalid choice");
				break;
		}
		Console.WriteLine();
	} while (choice != 2);

}
//Triangle triangle = new Triangle(0, 0, 0, 4, 3, 0);
//double[] medians = triangle.Medians();
//Console.WriteLine("Медіани трикутника: {0}, {1}, {2}", medians[0], medians[1], medians[2]);

//// Створення об 'єктів трикутників
//static void Menu()
//{
//	Triangle t1 = new Triangle(0, 0, 1, 1, 2, 2);
//	Triangle t2 = new Triangle(0, 0, 1, 1, 2, 2);
//	Triangle t3 = new Triangle(0, 0, 1, 1, 3, 3);
//	Console.WriteLine("Виберіть дію:");
//	Console.WriteLine("1. Чи рівні два трикутники?");
//	Console.WriteLine("2. Площа трикутника");
//	Console.WriteLine("3. Вихід з програми");
//	Console.Write("Ваш вибір: ");
//	string input = Console.ReadLine();
//	Console.WriteLine();

//	switch (input)
//	{
//		case "1":
//			// Чи рівні два трикутники
//			Console.WriteLine("Ви вибрали 'Чи рівні два трикутники?'.");
//			// TODO: додати код для цього пункту меню
//			D1(t1,t2,t3);
//			break;
//		case "2":
//			// Площа трикутника
//			Console.WriteLine("Ви вибрали 'Площа трикутника'.");
//			// TODO: додати код для цього пункту меню
//			break;
//		case "3":
//			// Вихід з програми
//			Console.WriteLine("Дякуємо за використання програми. До побачення!");
//			return;
//		default:
//			// Невірний ввід
//			Console.WriteLine("Невірний ввід. Спробуйте ще раз.");
//			break;
//	}

//	Console.WriteLine();
//}

////Triangle t1 = new Triangle(0, 0, 1, 1, 2, 2);
////Triangle t2 = new Triangle(0, 0, 1, 1, 2, 2);
////Triangle t3 = new Triangle(0, 0, 1, 1, 3, 3);

//// Порівняння трикутників
//static void D1(var t1, var t2, var t3)
//{
//	Console.WriteLine("Трикутник 1 і Трикутник 2 рівні: " + t1.Compare(t2));
//	Console.WriteLine("Трикутник 1 і Трикутник 3 рівні: " + t1.Compare(t3));
//}
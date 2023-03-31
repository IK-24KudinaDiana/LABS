//Написати програму згідно отриманого завдання використовуючи лише LINQ методи.
//	В кінці завдання в дужках наведена підказка, які методи LINQ могли б вам
//	допомогти у розв'язанні задачі

//Дана цифра D (ціле однозначне число) і послідовність цілих чисел A.
//	Витягти з A всі різні додатні числа, що закінчуються цифрою D (в вихідному порядку).
//	При наявності повторюваних елементів видаляти всі їх входження, крім останніх. 
//	Порада: Послідовно застосувати методи Reverse, Distinct, Reverse. (2)


do
{
	Console.Clear();
	int number;
	int[] myarray = { 1, 25, 35, -45, 65, 23, -85, 95, 25, 95 };
	var result = myarray.Sum();

	if (TryInputValue("Enter a number between 0 and 9: ", out number))
	{
		ActionsWithArray(myarray);
		LINQ(myarray, number);
	}

	Console.WriteLine("\n You want to complete the program: yes or no");
} while (!(string.Equals(Console.ReadLine(), "yes", StringComparison.OrdinalIgnoreCase)));

static bool TryInputValue(string argumentName, out int value)
{
	Console.Write($"{argumentName}");
	string stringValue = Console.ReadLine();
	if (int.TryParse(stringValue, out value))
	{
		if (value >= 0 && value <= 9)
		{
			return true;
		}
	}
	Console.WriteLine($"You wrote incorrect value {stringValue}");
	return false;
}

static void LINQ(int[] myarray, int number)
{
	//var result = myarray.Reverse()
	//				  .Distinct()
	//				  .Where(x => x > 0 && x % 10 == number)
	//				  .Reverse();
	var result = myarray.Sum();
	Console.WriteLine($"\n Result: {result}");
	//foreach (int i in result)
	//{
	//	Console.Write(i /*+ "\t"*/);
	//}
}
static void ActionsWithArray(int[] myarray)
{
	Console.WriteLine(" My array: ");
	foreach (int number in myarray)
	{
		Console.Write(number + "\t");
	}
}
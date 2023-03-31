//Написати програму згідно отриманого завдання використовуючи колекції C#.

//Дано список цілих чисел і число X. Не використовуючи допоміжних об'єктів і не змінюючи розміру списку, переставити елементи списку наступним чином:
//Задати Х з клавіатури
//Нехай x=5
//Було: 1 2 3 4 5 6 7 8 9
//Стало: 4 3 2 1 5 9 8 7 6

do
{
	Console.Clear();
	int number;
	if (TryInputValue("Введiть число вiд 1 до 9: ", out number))
	{
		List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		ListOutput(number, list);
		ActionsWithAList(number, ref list);
		ListOutput(number, list);
	}

	Console.WriteLine("\n You want to complete the program: yes or no");
} while (!(string.Equals(Console.ReadLine(), "yes", StringComparison.OrdinalIgnoreCase)));


static bool TryInputValue(string argumentName, out int value)
{
	Console.WriteLine($"{argumentName}");
	string stringValue = Console.ReadLine();
	if (int.TryParse(stringValue, out value))
	{
		return true;
	}
	Console.WriteLine($"You wrote incorrect value {stringValue}");
	return false;
}
static void ListOutput(int number, List<int> list)
{
	Console.WriteLine();
	foreach (int i in list)
		Console.Write(i + "   ");
	Console.WriteLine();
}

static void ActionsWithAList(int number, ref List<int> list)
{
	
	for (int i = 0; i < list.Count; i++)
	{
		if (list[i] == number)
		{
			list.Reverse(0, number - 1);
			list.Reverse(number, 9 - number);
		}	
	}
}







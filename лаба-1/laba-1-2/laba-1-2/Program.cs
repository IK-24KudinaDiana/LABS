//Написати програму згідно отриманого завдання використовуючи словники Dictionary в C#.
//	Якщо результатом виконання програми є словник, зберегти цей результат у JSON файл
//Дано словник.
//	Вивести тільки ті позиції словника, в яких ключ більший або дорівнює заданому значенню. 
//	Повернути null, якщо такого ключа не існує.Записати у JSON
using Newtonsoft.Json;
do
{
	Console.Clear();
	int n;
	if (TryInputValue("Введiть значення: ", out n))
	{
		Dictionary<int, string> MyDictionary = new Dictionary<int, string>()
		{
			{ 1, "The moon" },
			{ 2, "Earth" },
			{ 3, "Sun " },
			{ 4, "Mars" }
		};
		Dictionary<int, string> MyDictionary1 = new Dictionary<int, string>();

		KeyVerification(MyDictionary, n);
		ActionsWithTheDictionary(MyDictionary, ref MyDictionary1, n);
		Json(MyDictionary1);

	}

	Console.WriteLine("\n You want to complete the program: yes or no");
} while (!(string.Equals(Console.ReadLine(), "yes", StringComparison.OrdinalIgnoreCase)));
static bool TryInputValue(string argumentName, out int value)
{
	Console.Write($"{argumentName}");
	string stringValue = Console.ReadLine();
	if (int.TryParse(stringValue, out value))
	{
		return true;
	}
	Console.WriteLine($"You wrote incorrect value {stringValue}");
	return false;
}

static void Json(Dictionary<int, string> MyDictionary1)
{
	string file = "E:\\Навчання\\1.txt";
	string json = JsonConvert.SerializeObject(MyDictionary1);
	StreamWriter sw = new StreamWriter(file);
	sw.WriteLine(json);
	sw.Close();
}
static void ActionsWithTheDictionary(Dictionary<int, string> MyDictionary, ref Dictionary<int, string> MyDictionary1, int n)
{
	int k = 1;
	foreach (var key in MyDictionary)
	{
		if (k >= n)
		{
			Console.WriteLine($"key: {key.Key}  value: {key.Value}");
			MyDictionary1.Add(key.Key, key.Value);
		}
		k++;
	}
}
static void KeyVerification(Dictionary<int, string> MyDictionary, int n)
{
	bool DictionaryKey = MyDictionary.ContainsKey(n);
	if (DictionaryKey == false)
	{
		Console.WriteLine("null");
	}
	//Console.WriteLine($"Key: {DictionaryKey}");
}

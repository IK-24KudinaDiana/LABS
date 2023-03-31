

using Newtonsoft.Json;
using System.Drawing;
using System.Text;

namespace test_5___laba_3
{
	internal class Triangle
	{
		public double x1, y1, x2, y2, x3, y3;

		public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
		{
			this.x1 = x1;
			this.y1 = y1;
			this.x2 = x2;
			this.y2 = y2;
			this.x3 = x3;
			this.y3 = y3;
		}

		// Метод, який повертає довжину сторони трикутника
		private double SideLength(double x1, double y1, double x2, double y2)
		{
			return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
		}
		// Метод для порівняння з іншим трикутником за координатами вершин
		public bool Equals(Triangle other)
		{
			// Перевірка, чи всі координати вершин співпадають
			if (x1 == other.x1 && y1 == other.y1 && x2 == other.x2 && y2 == other.y2 && x3 == other.x3 && y3 == other.y3)
			{
				return true;
			}
			return false;
		}
		public double Area()
		{
			double a = SideLength(x1, y1, x2, y2);
			double b = SideLength(x2, y2, x3, y3);
			double c = SideLength(x3, y3, x1, y1);
			double p = (a + b + c) / 2;
			return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
		}
		public double Perimeter()
		{
			double a = SideLength(x1, y1, x2, y2);
			double b = SideLength(x2, y2, x3, y3);
			double c = SideLength(x3, y3, x1, y1);
			return a + b + c;
		}
		public double[] Heights()
		{
			double a = SideLength(x1, y1, x2, y2);
			double b = SideLength(x2, y2, x3, y3);
			double c = SideLength(x3, y3, x1, y1);
			double p = Perimeter() / 2;
			double ha = 2 * Math.Sqrt(p * (p - a) * (p - b) * (p - c)) / a;
			double hb = 2 * Math.Sqrt(p * (p - a) * (p - b) * (p - c)) / b;
			double hc = 2 * Math.Sqrt(p * (p - a) * (p - b) * (p - c)) / c;
			return new double[] { ha, hb, hc };
		}
		public double[] Medians()
		{
			double mx1 = (x2 + x3) / 2;
			double my1 = (y2 + y3) / 2;
			double mx2 = (x1 + x3) / 2;
			double my2 = (y1 + y3) / 2;
			double mx3 = (x1 + x2) / 2;
			double my3 = (y1 + y2) / 2;
			return new double[] { SideLength(mx1, my1, x1, y1), SideLength(mx2, my2, x2, y2), SideLength(mx3, my3, x3, y3) };
		}
		public double[] Bisectors()
		{
			double a = SideLength(x2, y2, x3, y3);
			double b = SideLength(x1, y1, x3, y3);
			double c = SideLength(x1, y1, x2, y2);

			double alpha = Math.Acos((b * b + c * c - a * a) / (2 * b * c));
			double beta = Math.Acos((a * a + c * c - b * b) / (2 * a * c));
			double gamma = Math.Acos((a * a + b * b - c * c) / (2 * a * b));

			double[] bisectors = new double[3];
			bisectors[0] = 2 * b * c * Math.Cos(alpha / 2) / (b + c);
			bisectors[1] = 2 * a * c * Math.Cos(beta / 2) / (a + c);
			bisectors[2] = 2 * a * b * Math.Cos(gamma / 2) / (a + b);

			return bisectors;
		}


		// Метод, який повертає радіус вписаного кола трикутника
		public double InCircleRadius()
		{
			double a = SideLength(x2, y2, x3, y3);
			double b = SideLength(x1, y1, x3, y3);
			double c = SideLength(x1, y1, x2, y2);

			double p = Perimeter() / 2;

			double inCircleRadius = Math.Sqrt(((p - a) * (p - b) * (p - c)) / p);

			return inCircleRadius;
		}
		// Метод, який повертає радіус описаного кола трикутника
		public double CircumCircleRadius()
		{
			double a = SideLength(x2, y2, x3, y3);
			double b = SideLength(x1, y1, x3, y3);
			double c = SideLength(x1, y1, x2, y2);

			double circumCircleRadius = (a * b * c) / (4 * Area());

			return circumCircleRadius;
		}
	
		public string Type()
		{
			double a = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
			double b = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
			double c = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));

			if (a == b && b == c)
			{
				return "Рiвностороннiй";
			}
			else if (a == b || b == c || a == c)
			{
				return "Рiвнобедрений";
			}
			else if (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a)
			{
				return "Прямокутний";
			}
			else if (a * a + b * b < c * c || a * a + c * c < b * b || b * b + c * c < a * a)
			{
				return "Тупокутний";
			}
			else
			{
				return "Гострокутний";
			}
		}

		// Поворот на заданий кут відносно вершини трикутника
		public void Rotate(double angle, int vertexIndex)
		{
			double centerX = (x1 + x2 + x3) / 3.0;
			double centerY = (y1 + y2 + y3) / 3.0;

			double radians = angle * Math.PI / 180.0;
			double cos = Math.Cos(radians);
			double sin = Math.Sin(radians);

			switch (vertexIndex)
			{
				case 1:
					x1 = centerX + (x1 - centerX) * cos - (y1 - centerY) * sin;
					y1 = centerY + (x1 - centerX) * sin + (y1 - centerY) * cos;
					break;
				case 2:
					x2 = centerX + (x2 - centerX) * cos - (y2 - centerY) * sin;
					y2 = centerY + (x2 - centerX) * sin + (y2 - centerY) * cos;
					break;
				case 3:
					x3 = centerX + (x3 - centerX) * cos - (y3 - centerY) * sin;
					y3 = centerY + (x3 - centerX) * sin + (y3 - centerY) * cos;
					break;
				default:
					throw new ArgumentException("Vertex index must be between 1 and 3.");
			}
		}
		// Поворот на заданий кут відносно центру описаного кола
		public void Rotate(double angle)
		{
			double centerX = (x1 + x2 + x3) / 3;
			double centerY = (y1 + y2 + y3) / 3;
			double radians = angle * Math.PI / 180.0;
			double cos = Math.Cos(radians);
			double sin = Math.Sin(radians);
			double x1New = centerX + (x1 - centerX) * cos - (y1 - centerY) * sin;
			double y1New = centerY + (x1 - centerX) * sin + (y1 - centerY) * cos;
			double x2New = centerX + (x2 - centerX) * cos - (y2 - centerY) * sin;
			double y2New = centerY + (x2 - centerX) * sin + (y2 - centerY) * cos;
			double x3New = centerX + (x3 - centerX) * cos - (y3 - centerY) * sin;
			double y3New = centerY + (x3 - centerX) * sin + (y3 - centerY) * cos;
			x1 = x1New;
			y1 = y1New;
			x2 = x2New;
			y2 = y2New;
			x3 = x3New;
			y3 = y3New;
		}

		public override string ToString()
		{
			return $"A({Math.Round(x1, 1)}, {Math.Round(y1, 1)}), B({Math.Round(x2, 1)}, {Math.Round(y2, 1)}), C({Math.Round(x3, 1)}, {Math.Round(y3, 1)})";
		}

		public static void SerializeToFile<T>(T obj, string filePath)
		{
			try
			{
				string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
				File.WriteAllText(filePath, json);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error serializing object to file: {ex.Message}");
			}
		}

		public static T DeserializeFromFile<T>(string filePath)
		{
			try
			{
				string json = File.ReadAllText(filePath);
				return JsonConvert.DeserializeObject<T>(json);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deserializing object from file: {ex.Message}");
				return default(T);
			}
		}

		public static void Print<T>(T obj)
		{
			string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
			Console.WriteLine(json);
		}

	}
}
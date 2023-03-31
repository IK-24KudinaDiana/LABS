using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_4
{
	internal class Triangle
	{
		// координати вершин трикутника
		private double x1, y1, x2, y2, x3, y3;

		// конструктор класу
		public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
		{
			this.x1 = x1;
			this.y1 = y1;
			this.x2 = x2;
			this.y2 = y2;
			this.x3 = x3;
			this.y3 = y3;
		}
		public bool Compare(Triangle t)
		{
			if (this.x1 == t.x1 && this.y1 == t.y1 && this.x2 == t.x2 && this.y2 == t.y2 && this.x3 == t.x3 && this.y3 == t.y3)
			{
				return true;
			}
			return false;
		}
		// метод, який повертає площу трикутника
		public double Area()
		{
			double a = SideLength(x1, y1, x2, y2);
			double b = SideLength(x2, y2, x3, y3);
			double c = SideLength(x3, y3, x1, y1);
			double p = (a + b + c) / 2;
			return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
		}

		// метод, який повертає периметр трикутника
		public double Perimeter()
		{
			double a = SideLength(x1, y1, x2, y2);
			double b = SideLength(x2, y2, x3, y3);
			double c = SideLength(x3, y3, x1, y1);
			return a + b + c;

		}
		//// метод, який повертає периметр трикутника
		//public double Perimeter()
		//{
		//	double a = SideLength(x1, y1, x2, y2);
		//	double b = SideLength(x2, y2, x3, y3);
		//	double c = SideLength(x3, y3, x1, y1);
		//	return a + b + c;
		//}

		// метод, який повертає довжину сторони трикутника
		private double SideLength(double x1, double y1, double x2, double y2)
		{
			return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
		}

		// метод, який повертає висоти трикутника
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
		// метод, який повертає медіани трикутника
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
		// метод, який повертає бісектриси трикутника
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

		// метод, який повертає радіус вписаного кола трикутника
		public double InCircleRadius()
		{
			double a = SideLength(x2, y2, x3, y3);
			double b = SideLength(x1, y1, x3, y3);
			double c = SideLength(x1, y1, x2, y2);

			double p = Perimeter() / 2;

			double inCircleRadius = Math.Sqrt(((p - a) * (p - b) * (p - c)) / p);

			return inCircleRadius;
		}

		// метод, який повертає радіус описаного кола трикутника
		public double CircumCircleRadius()
		{
			double a = SideLength(x2, y2, x3, y3);
			double b = SideLength(x1, y1, x3, y3);
			double c = SideLength(x1, y1, x2, y2);

			double circumCircleRadius = (a * b * c) / (4 * Area());

			return circumCircleRadius;
		}
		// Метод, що повертає тип трикутника
		public string Type()
		{
			double a = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
			double b = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
			double c = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));

			if (a == b && b == c)
			{
				return "Рівносторонній";
			}
			else if (a == b || b == c || a == c)
			{
				return "Рівнобедрений";
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
		// Повертає координати вершин трикутника
		public double[] GetVertices()
		{
			return new double[] { x1, y1, x2, y2, x3, y3 };
		}

		// Поворот на заданий кут відносно вершини трикутника
		public void Rotate(double angle, int vertexIndex)
		{
			double cx, cy; // координати центра трикутника
			cx = (x1 + x2 + x3) / 3;
			cy = (y1 + y2 + y3) / 3;

			// віднімаємо координати центра трикутника, щоб після повороту трикутник залишився на місці
			x1 -= cx;
			y1 -= cy;
			x2 -= cx;
			y2 -= cy;
			x3 -= cx;
			y3 -= cy;

			// перетворення координат вершин трикутника за формулою повороту точки (x, y) на заданий кут навколо початку координат
			double rad = angle * Math.PI / 180; // переведення у радіани
			double cos = Math.Cos(rad);
			double sin = Math.Sin(rad);
			double newX1 = x1 * cos - y1 * sin;
			double newY1 = x1 * sin + y1 * cos;
			double newX2 = x2 * cos - y2 * sin;
			double newY2 = x2 * sin + y2 * cos;
			double newX3 = x3 * cos - y3 * sin;
			double newY3 = x3 * sin + y3 * cos;

			// додаємо координати центра трикутника назад
			x1 = newX1 + cx;
			y1 = newY1 + cy;
			x2 = newX2 + cx;
			y2 = newY2 + cy;
			x3 = newX3 + cx;
			y3 = newY3 + cy;
		}
		// метод, який повертає координати центру описаного кола
		private (double, double) Circumcenter()
		{
			double a = x2 - x1;
			double b = y2 - y1;
			double c = x3 - x1;
			double d = y3 - y1;
			double e = a * (x1 + x2) + b * (y1 + y2);
			double f = c * (x1 + x3) + d * (y1 + y3);
			double g = 2 * (a * (y3 - y2) - b * (x3 - x2));
			if (g == 0) // коло неможливо обчислити
			{
				throw new Exception("Triangle is degenerate.");
			}
			double centerX = (d * e - b * f) / g;
			double centerY = (a * f - c * e) / g;
			return (centerX, centerY);
		}

		// метод, який повертає координати вершин трикутника після повороту на заданий кут відносно центру описаного кола
		public (double, double, double, double, double, double) Rotate(double angle)
		{
			(double centerX, double centerY) = Circumcenter();
			double cosA = Math.Cos(angle);
			double sinA = Math.Sin(angle);
			double x1New = centerX + (x1 - centerX) * cosA - (y1 - centerY) * sinA;
			double y1New = centerY + (x1 - centerX) * sinA + (y1 - centerY) * cosA;
			double x2New = centerX + (x2 - centerX) * cosA - (y2 - centerY) * sinA;
			double y2New = centerY + (x2 - centerX) * sinA + (y2 - centerY) * cosA;
			double x3New = centerX + (x3 - centerX) * cosA - (y3 - centerY) * sinA;
			double y3New = centerY + (x3 - centerX) * sinA + (y3 - centerY) * cosA;
			return (x1New, y1New, x2New, y2New, x3New, y3New);
		}
	}
}

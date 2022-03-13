using System;
using System.Text;
namespace consoleCalc
{
	class Program
	{
		static readonly char[] массивЗнаков = { '+', '-', '*', '/', '^', '%', '!'}; //, ')', '(' 
		static readonly char[] цифры = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
		static int количествоЗнаков = 0;
		static void Main() 
		{
			Console.Write("доступные знаки: "); 
			ВыводМассиваЗнаков(); 
			Console.Write("\nвведите выражение: ");
			string выражение = Нажатие_клавиш();
			Console.WriteLine($"\nвы ввели: {выражение}");
			//Calc(выражение);
			//Console.WriteLine($"\nответ: {Calc(выражение)}"); 
		}
		static string Нажатие_клавиш()
		{
			StringBuilder ввод = new StringBuilder(null);
			ConsoleKeyInfo клавиша;
			bool exit;
			do
			{
				клавиша = Console.ReadKey(true);
				if (клавиша.Key == ConsoleKey.Backspace && ввод.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Console.Write(' ');
					ввод.Remove(ввод.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				for (int i = 0; i < цифры.Length; i++)
				{
					if (ввод.Length > 0 && ввод[^1] == '!') break;
					else if (клавиша.KeyChar == цифры[i])
					{
						Console.Write(цифры[i]);
						ввод.Append(клавиша.KeyChar);
						break;
					}
				}
				exit = false;
				for (int i = 0; i < массивЗнаков.Length; i++)
				{
					if (ввод.Length == 0 && клавиша.KeyChar != '-') break;
					for (int j = 0; j < массивЗнаков.Length; j++)
					{
						if (ввод.Length > 0 && ввод[^1] == массивЗнаков[j] && ввод[^1] != '!') //если прошлый символ равен знаку - выход из цикла ввода знака
						{
							exit = true;
							break; //C# упростил: ввод[ввод.Length - 1]
						}
					}
					if (exit) break;
					if (клавиша.KeyChar == массивЗнаков[i])
					{
						Console.Write(массивЗнаков[i]);
						ввод.Append(клавиша.KeyChar);
						количествоЗнаков++;
						break;
					}
				}
			} while (клавиша.Key != ConsoleKey.Enter);
			return ввод.ToString();
		}
		static void ВыводМассиваЗнаков()
		{
			for (int i = 0; i < массивЗнаков.Length; i++) 
			{ 
				Console.Write(массивЗнаков[i]); 
				if (массивЗнаков.Length - 1 != i) Console.Write(", ");
				else Console.Write(".");
			}
		}
		static void Calc(string выр)
		{
			bool brek = false;
			for (int i = 0; i < выр.Length; i++)
			{
				for (int j = 0; j < массивЗнаков.Length; j++)
				{
					if (выр[i] != 0 && выр[i] == массивЗнаков[j])
					{
						break;
						brek = true;
					}
				}
				if (brek) break;
			}
		}




































		static double Факториал(int n)
		{
			double ans = 1;
			for (int i = 2; i <= n; i++) ans *= i;
			return ans;
		}
		static int Степень(int a, int b)
		{
			int ans = 1;
			for (int i = 0; i < b; i++) ans *= a;
			return ans;
		}
		/*
		static double Calc(string выр)
		{
			double ans = 0;
			int pos;
			//поиск количества всех знаков
			//поиск знака и определение
			if (количествоЗнаков == 0) pos = выр.Length;
			else pos = Где(выр, out char знак);
			//определение чисел
			//ans = Числа(выр, pos, количествоЗнаков);
			return ans;
		}
		static double Числа(string выр, int след_знак, int повторения)
		{ 
			int пред_знак = -1;
			double first = Число(пред_знак, след_знак, выр);
			return first;
		}
		static double Число(int МестоПервогоЗнака, int местоВторогоЗнака, string гдеИскать)
		{
			string число = "";
			for (int i = МестоПервогоЗнака + 1; i < местоВторогоЗнака; i++) число += гдеИскать[i];
			return Convert.ToDouble(число);
		}
		static int Где(string выр, out char знак)
		{
			int pos = выр.Length;
			знак = '0';
			bool brek = false;
			for (int i = 0; i < выр.Length; i++)
			{
				pos = i;
				знак = Свич(выр[i], ref pos, ref brek);
				if (brek) break;
			}
			return pos;
		}
		static char Свич(char откуда_искать, ref int итерация, ref bool брейк)
		{
			char знак = '0';
			switch (откуда_искать)
			{
				case '+':
					знак = '+';
					брейк = true;
					break;
				case '-':
					знак = '-';
					брейк = true;
					break;
				case '*':
					знак = '*';
					брейк = true;
					break;
				case '/':
					знак = '/';
					брейк = true;
					break;
			}
			if (знак == '0') итерация = -1;
			return знак;
		}
		*/
	}
}
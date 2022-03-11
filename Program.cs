using System;

namespace consoleCalc
{
	class Program
	{
		static readonly char[] массивЗнаков = { '+', '-', '*', '/', '^', '%'}; //скобки потом
		static void Main() 
		{ 
			Console.Write("доступные знаки: "); 
			ВыводМассиваЗнаков(); 
			Console.Write("\nвведите выражение: "); 
			string выражение = Console.ReadLine();
			Console.WriteLine($"ответ: {Calc(выражение)}"); 
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
		static double Calc(string выр)
		{
			double ans = 0;
			int pos;
			//поиск количества всех знаков
			int колво_знаков = Сколько(выр);
			//поиск знака и определение
			if (колво_знаков == 0) pos = выр.Length;
			else pos = Где(выр, out char знак);
			//определение чисел
			ans = Числа(выр, pos, колво_знаков);
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
		static int Сколько(string выр)
		{
			int счётчикСовпадений = 0;
			for (int i = 0; i < выр.Length; i++)
			{
				for (int j = 0; j < массивЗнаков.Length; j++)
				{
					if (выр[i] == массивЗнаков[j]) счётчикСовпадений++;
				}
			}
			return счётчикСовпадений;
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
		static int Степень(int a, int b)
		{
			int ans = 1;
			for (int i = 0; i < b; i++) ans *= a;
			return ans;
		}
	}
}
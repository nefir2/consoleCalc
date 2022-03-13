using System;
using System.Text;
namespace consoleCalc
{
    class Program
    {
        static readonly char[] массивЗнаков = { '+', '-', '*', '/', '^', '%', '!' }; //, ')', '(' 
        static readonly char[] цифры = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int количествоЗнаков = 0;
        static void Main()
        {
            string выражение;
            Console.Write("если ввести \"0\", то программа завершится.\n");
            Console.Write("доступные знаки: ");
            ВыводМассиваЗнаков();
            do
            {
                Console.Write("\nвведите выражение: ");
                выражение = Нажатие_клавиш();
                Console.Clear();
                if (выражение != "0") Console.WriteLine($"вы ввели: {выражение}\nколичество знаков: {количествоЗнаков}\n");
                количествоЗнаков = 0;
                //Calc(выражение);
                //Console.WriteLine($"\nответ: {Calc(выражение)}"); 
            } while (выражение != "0");
        }
        static string Нажатие_клавиш()
        {
            StringBuilder ввод = new StringBuilder(null);
            ConsoleKeyInfo клавиша;
            bool exit;
            do
            {
                клавиша = Console.ReadKey(true);
                Console.Clear();
                Console.WriteLine($"\nнажатая клавиша:\n\nпеременная: {клавиша},\nключ: {клавиша.Key},\nсимвол: {клавиша.KeyChar}.\n");
                if (клавиша.Key == ConsoleKey.Backspace && ввод.Length > 0)
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(' ');
                    for (int i = 0; i < массивЗнаков.Length; i++)
                    {
                        if (ввод.Length > 0 && ввод[^1] == массивЗнаков[i])
                        {
                            количествоЗнаков--;
                            break;
                        }
                    }
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
                        if (ввод.Length > 0 && ввод[^1] == '!' && клавиша.KeyChar == '!')
                        {
                            exit = true;
                            break;
                        }
                        if (ввод.Length > 0 && ввод[^1] == массивЗнаков[j] && ввод[^1] != '!') //если прошлый символ равен знаку - выход из цикла ввода знака
                        {//C# упростил: ввод[ввод.Length - 1]
                            exit = true;
                            break;
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
                /*
				if (клавиша.Key == ConsoleKey.Enter)
                {
					for (int i = 0; i < массивЗнаков.Length; i++)
                    {
						if (ввод[^1] == массивЗнаков[i] && ввод[^1] != '!')
                        {
							клавиша = 0;
                        }
                    }
                }
				*/
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
            /*
			for (int i = 0; i < выр.Length; i++)
            {
				if (выр[i] == '*' || выр[i] == '/' || выр[i] == '%')
            }
			*/
            //определение границ в виде знаков первого числа
            int znak1, znak2;
            bool brek = false; //булевая переменная для выхода из второго цикла
            if (выр[0] == '-') znak1 = 0; //если первый знак - минус
            else if (выр[0] != '-')
            {//если первый знак не минус, то начинаем поиск
                for (int i = 1; i < выр.Length; i++)
                {//проход по массиву выражения со второго символа, т.к. на первом месте может быть только минус (из функции "нажатие_клавиш")
                    for (int j = 0; j < массивЗнаков.Length; j++)
                    {//проход по массиву знаков
                        if (выр[i] == массивЗнаков[j])
                        {//если нашёлся знак, то сохранение первого знака и выход из двух циклов
                            znak1 = выр[i];
                            brek = true; //выход со второго
                            break; //выход с первого цикла
                        }
                    }
                    if (brek) break; //выход со второго
                }
            }
            else
            {
                znak1 = -1;
                znak2 = выр.Length;
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
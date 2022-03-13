﻿using System;
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
			string выражение; //переменная где хранится введённое выражение пользователем
			Console.Write("если ввести \"0\", то программа завершится.\n");
			Console.Write("доступные знаки: ");
			ВыводМассиваЗнаков();
			do
			{//цикл для неодноразового ввода выражения
				Console.Write("\nвведите выражение: ");
				выражение = Нажатие_клавиш();
				Console.Clear(); //очистка консоли после ввода
				if (выражение != "0") Console.WriteLine($"вы ввели: {выражение}\nколичество знаков: {количествоЗнаков}\n"); //вывод инфы для дебага
				количествоЗнаков = 0; //зануление количества знаков после ввода выражения
				//Calc(выражение);
				//Console.WriteLine($"\nответ: {Calc(выражение)}"); 
			} while (выражение != "0"); // 13 строка.
		}
		static string Нажатие_клавиш()
		{//функция слушающая каждое нажатие клавиши и возвращающая строку.
			StringBuilder ввод = new StringBuilder(); //систем.текст. вместо string для более удобной работы со строкой
			ConsoleKeyInfo клавиша; //переменная где хранится значение клавишы
			bool exit, циклВвода = true; //булевая переменная для обхода ввода знака
			do
			{//цикл для окончания ввода. если нажать Enter то ввод закончится и вернётся строка
				клавиша = Console.ReadKey(true); //запоминание нажатой клавишы
				if (клавиша.Key == ConsoleKey.Enter) циклВвода = false;
				if (клавиша.Key == ConsoleKey.Backspace && ввод.Length > 0)
				{//если был нажата клавиша backspace и стирать ещё осталось что
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); //перемещение курсора на одну позицию назад
					Console.Write(' '); //замещение символа в этой позиции на пробел
					for (int i = 0; i < массивЗнаков.Length; i++)
					{//проверка последнего введённого символа на знаки
						if (ввод.Length > 0 && ввод[^1] == массивЗнаков[i])
						{//если стёртый символ оказался знаком
							количествоЗнаков--; //уменьшение количества знаков
							break; //выход из цикла
						}
					}
					ввод.Remove(ввод.Length - 1, 1); //удаление стёртого с экрана
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); //снова перемещение курсора на одну позицию назад
				}//backspace
				for (int i = 0; i < цифры.Length; i++)
				{//проверка введённого символа на цифры
					if (ввод.Length > 0 && ввод[^1] == '!') break; //если предыдущий знак не выпадает за область массива и предыдущий знак - !, то выход из цикла ввода цифр
					else if (клавиша.KeyChar == цифры[i])
					{//если нажатая клавиша совпала с цифрой
						Console.Write(цифры[i]); //вывод нажатой цифры
						ввод.Append(клавиша.KeyChar); //добавление в массив вводимых символов введённую цифру через стринбилдер
						break; //выход из цикла чтобы лишние круги не проходить в пустую
					}
				}//цикл цифры
				exit = false; //значение для переменной чтобы не выходить из цикла раньше времени
				for (int i = 0; i < массивЗнаков.Length; i++)
				{//проверка введённого символа на знаки
					if (ввод.Length == 0 && клавиша.KeyChar != '-') break; //если это первый символ, и вводимый знак не минус, то выход из цикла ввода знака
					for (int j = 0; j < массивЗнаков.Length; j++)
					{//проверка на прошлый знак и факториал заранее
						if (ввод.Length > 0 && ввод[^1] == '!' && клавиша.KeyChar == '!')
						{//если введённых символов больше 0, чтобы не выпасть за массив символов, и предыдущий знак и только что введённый это факториал, то выход из цикла ввода знаков 
							exit = true; //выход из основного цикла ввода знаков
							break; //выход из этого цикла
						}//дважды одинакого написанные тела условного оператора для упрощения кода
						if (ввод.Length > 0 && ввод[^1] == массивЗнаков[j] && ввод[^1] != '!') //C# упростил: ввод[ввод.Length - 1] это тоже самое что ввод[^1]
						{//если прошлый символ равен знаку и не равен факториалу, то выход из цикла ввода знака
							exit = true;
							break;
						}
					}//прошлый знак и факториал
					if (exit) break; //выход из основного цикла
					if (клавиша.KeyChar == массивЗнаков[i])
					{//если введённый символ это знак
						Console.Write(массивЗнаков[i]); //вывод введённого символа
						ввод.Append(клавиша.KeyChar); //добавление введённого символа в массив введённых символов
						количествоЗнаков++; //прибавление, в счётчик количества знаков, еденицы
						break; //выход из цикла
					}
				}//цикл знаки
				
				if (клавиша.Key == ConsoleKey.Enter)
				{//если нажатая клавиша enter
					for (int i = 0; i < массивЗнаков.Length; i++)
					{//проверка последнего введённого символа на знаки
						if (ввод[^1] == массивЗнаков[i] && ввод[^1] != '!')
						{//если последний знак не факториал
							циклВвода = true; //попытка возврата в цикл не enter
							Console.Clear(); //очистка консоли
							Console.WriteLine("нельзя решить выражение если нет числа справа"); 
							Console.Write($"выражение: {ввод}"); //вывод введённого выражения обратно
						}
					}//последний символ
				}//enter
			} while (циклВвода);
			return ввод.ToString(); //перевод введённого выражения из стринбилдера в стрин и возврат из функции
		}
		static void ВыводМассиваЗнаков()
		{//я думаю, название говорит само за себя :)
			for (int i = 0; i < массивЗнаков.Length; i++)
			{//проход по массиву знаков
				Console.Write(массивЗнаков[i]); //вывод очередного знака
				if (массивЗнаков.Length - 1 != i) Console.Write(", "); //если знак ещё не последний - ставится запятая
				else Console.Write("."); //если знак последний - точка
			}
		}
		static void Calc(string выр)
		{//функция которая считает ответ выражения
			/*
			for (int i = 0; i < выр.Length; i++)
			{//поиск знаков более важных чем + или -
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
		{//функция для вычисления факториала числа
			double ans = 1; //переменная где будет ответ
			for (int i = 2; i <= n; i++) ans *= i; //умножение ответа на номер итерации, параметр n раз
			return ans;
		}
		static int Степень(int a, int b)
		{//функция для вычисления степени числа
			int ans = 1; //переменная для ответа
			for (int i = 0; i < b; i++) ans *= a; //умножение ответа на a параметр, параметр b раз
			return ans;
		}
























		//мусор из старых версий программы. может пригодится
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
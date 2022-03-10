using System;

namespace consoleCalc
{
    class Program
    {
        static void Main()
        {
            Console.Write("доступные знаки: +, -, *, /.\nвведите выражение: ");
            string выражение = Console.ReadLine();
            Console.WriteLine($"ответ: {Calc(выражение)}");
        }
        static double Calc(string выр)
        {
            //переменные
            double ans = 0;
            int pos;
            int колво_знаков = 0;
            //поиск количества всех знаков
            колво_знаков += Сколько(выр, "+");
            колво_знаков += Сколько(выр, "-");
            колво_знаков += Сколько(выр, "*");
            колво_знаков += Сколько(выр, "/");
            //поиск знака и определение
            char знак;
            pos = Где(выр, out знак);

            return колво_знаков;
        }
        static int Сколько(string изКого, string что)
        {
            //bool ans = false;
            int счётчикСовпадений = 0;
            for (int i = 0; i < изКого.Length; i++) { if (изКого[i] == что[i]) счётчикСовпадений++; }
            return счётчикСовпадений;
        }
        static int Где(string выр, out char знак)
        {
            int pos = -1;
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
    }
}
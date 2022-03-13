//using System;
//namespace testing
//{
//    class TestFile
//    {
//        static void Main()
//        {
//            ConsoleKeyInfo клавиша;
//            bool end = true;
//            do
//            {
//                клавиша = Console.ReadKey(true);
//                Console.Clear();
//                Console.WriteLine($"нажатая клавиша:\n");
//                Console.WriteLine($"переменная: {клавиша},");
//                Console.WriteLine($"ключ: {клавиша.Key},");
//                Console.WriteLine($"символ: {клавиша.KeyChar}.");
//                Console.WriteLine($"дополнительная клавиша: {клавиша.Modifiers}");
//                if (клавиша.Modifiers == ConsoleModifiers.Control && клавиша.Key == ConsoleKey.Enter) end = false;
//            } while (end);
//        }
//    }
//}
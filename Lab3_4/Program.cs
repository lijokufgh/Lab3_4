namespace Lab3_4
{
    public class Urav
    {
        private int mod1, mod2, min = 0;
        private string uravn = "2x+|-3|-12 = 7"; //Уравнение.
        private string uravn1; // Копия уровнения над которой происходят манипуляции.
        private char[] uravn2; // Копия уровнения над которой происходят манипуляции в виде массива символов.

        private int Modul() // Метод нахождения модуля.
        {
            mod1 = uravn.IndexOf("|"); // Поиск индекса первого символа '|'.       
            uravn1 = uravn.Remove(0, mod1+1); // Удаление строки до первого '|' вмести с ним.
            mod2 = uravn1.LastIndexOf("|"); // Поиск индекса последнего символа '|'.  
            uravn1 = uravn1.Remove(mod2); // Удаление строки от последнего '|' вмести с ним.        
            mod1 = int.Parse(uravn1); // Парсинг строки в int.
            if (mod1 < 0) mod1 *= -1; // Проверка на отрицательность; если проходит, то домножение на -1.
            return mod1; // Возвращяем результат.
        }
        private int Ix()
        {
            mod1 = uravn.IndexOf("x"); // Поиск индекса символа 'x'.
            mod2 = mod1; 
            uravn1 = uravn.Remove(mod1); // Удаление строки от 'x' вмести с ним.
            uravn2 = ReverseChar(uravn1.ToCharArray()); // Перевод строки в массив символов вмести с реверсированием строки.
            PredX(); // Поиск длины множителя.
            uravn1 = new string(uravn2); // Перевод массива символов в строку.
            uravn1 = uravn1.Remove(mod2); // Удаление строки от моножетеля.
            uravn2 = ReverseChar(uravn1.ToCharArray()); // Перевод строки в массив символов вмести с реверсированием строки.
            uravn1 = new string(uravn2); // Перевод массива символов в строку.
            mod1 = int.Parse(uravn1); // Парсинг строки в int.
            if (min == 1) mod1 *= -1; // Проверка на отрицательность; если проходит, то домножение на -1.
            return mod1; // Возвращяем результат.
        }

        private void VodModul() // Вывод модуля.
        {
            Console.WriteLine($"Модуль: {Modul()}");
        }
        private void VodX() // Вывод множителя.
        {
            Console.WriteLine($"Множитель: {Ix()}");
        }
        private void PredX() // Поиск длины множителя. Поиск первого попавшегося символа и возвращение его индекса.
        {
            for (int i = 0; i < uravn2.Length; i++)
            {
                if (uravn2[i] == '=' || uravn2[i] == '+' || uravn2[i] == '-' || uravn2[i] == '/' || uravn2[i] == '%' || uravn2[i] == '*' || uravn2[i] == '|')
                {
                    if (uravn2[i] == '-') min = 1; // проверка на отрицательность.
                    mod2 = i;
                    return;
                }
               
            }            
        }
        private static char[] ReverseChar(char[] arr) // Реверсирование массива символов.
        {            
            Array.Reverse(arr);
            return arr;
        }

        public Urav() // Конструктор.
        {
            Console.WriteLine(uravn);
            VodModul();
            VodX();
        }
    }

    public class Program
    {
        static void Main()
        {
            Urav urav = new Urav();
        }        
    }
}
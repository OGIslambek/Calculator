namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            int a, b;

            try
            {
                Console.WriteLine("Введите число 1");
                a = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите число 2");
                b = int.Parse(Console.ReadLine());

                calculator.Calc(a, b);
            }

            catch (FormatException)
            {
                calculator.Event("Текст ошибки красный цвет, текст события синий цвет");
                Console.WriteLine("Ошибка: Некорректно введено значение.");
            }

            catch (Exception ex)
            {
                calculator.Event("Текст ошибки красный цвет, текст события синий цвет");
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }
        }

        public interface ICalculator
        {
            void Calc(int x, int y) { }
        }

        public class Calculator : ICalculator, ILogger
        {
            public void Event(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine(message);
            }
            public void Calc(int x, int y)
            {
                Console.WriteLine($"Сумма чисел {x + y}");
            }


        }

        public interface ILogger
        {
            void Event(string message);
        }
    }
}

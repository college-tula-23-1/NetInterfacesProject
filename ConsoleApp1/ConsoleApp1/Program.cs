namespace ConsoleApp1
{
    public class Circle
    {
        public double Radius { get; set; }
        public double Area() => 3.14 * Radius * Radius;

        public Circle(double radius)
        {
            if (radius < 0)
                throw new MyException($"Радиус должен быть положительным! {nameof(radius)}");
            Radius = radius;
        }
    }

    public class MyException : Exception
    {
        public MyException() : base() { }
        public MyException(string message) : base("MyException: " + message) { }
        public MyException(string message, Exception innerException) : base(message, innerException) { }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите радиус: ");
            var input = Console.ReadLine();
            if (input != null)
            {
                var radius = double.Parse(input);

                try
                {
                    var circle = new Circle(radius);
                    Console.WriteLine($"Площадь - {circle.Area()}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //Action<string> showMessage = delegate (string message)
            //{
            //    Console.WriteLine(message);
            //};
            //showMessage("Анонимный метод без возвращаемого значения");

            //Func<int, int, double> divide = delegate (int x, int y)
            //{
            //    return (double)x / y;
            //};
            //Console.WriteLine(divide(1, 2));

            //// лямбда-выражения
            //// (parameters) => expression
            //// (parameters) => { statements; }

            //var square = int (int x) => x * x;
            //var result = square(10);
            //Console.WriteLine(result);

            //int factor = 5;
            //var multiply = (int x) => x * factor;
            //result = multiply(10);
            //Console.WriteLine(result);

            //var mults = new List<Func<int, int>>();
            //for (int i = 1; i <= 3; ++i)
            //{
            //    int f = i;
            //    mults.Add((int x) => x * f);
            //}

            //foreach (var m in mults)
            //{
            //    var res = m(10);
            //    Console.WriteLine(res);
            //}

            ///*
            //try
            //{
            //}
            //catch
            //{
            //}
            // */

            //int num = 50;
            //int den = 0;
            //try
            //{
            //    int fraction = num / den;
            //    Console.WriteLine(fraction);
            //}
            //catch(Exception e) when (e.Message.Contains("zero"))
            //{
            //    Console.WriteLine("Перехвачено исключение");
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.Source);
            //    Console.WriteLine(e.StackTrace);
            //    return;
            //}
            //finally
            //{
            //    Console.WriteLine("Finally");
            //}

            //Console.WriteLine("Завершение программы");
        }
    }
}

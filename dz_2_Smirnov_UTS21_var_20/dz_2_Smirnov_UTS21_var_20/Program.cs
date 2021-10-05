using System;

namespace dz_2_Smirnov_UTS21_var_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите r1: ");
            double r1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите r2: ");
            double r2 = double.Parse(Console.ReadLine());

            tablefunction(r1, r2);
           
            Print_y_from_x(r1, r2);

        }

        private static void Print_y_from_x(double r1, double r2)
        {
            Console.WriteLine("---------Значение y от x------------");
            bool flag = true;
            do
            {
                Console.Write("Введите x: ");
                double x = double.Parse(Console.ReadLine());
                counter_y(r1, r2, x);

                int top = Console.CursorTop;
                int y = top;

                Console.WriteLine("--Ввести еще x--"); 
                Console.WriteLine("--Выйти--");

                int down = Console.CursorTop;

                Console.CursorSize = 100;
                Console.CursorTop = top;

                ConsoleKey key;
                while ((key = Console.ReadKey().Key) != ConsoleKey.Enter)
                {
                    if (key == ConsoleKey.UpArrow)
                    {
                        if (y > top)
                        {
                            y--;
                            Console.CursorTop = y;
                        }
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        if (y < down - 1)
                        {
                            y++;
                            Console.CursorTop = y;
                        }
                    }
                }

               

                if (y == top)
                    flag = true;
                else if (y == top + 1)
                    flag = false;

                Console.CursorTop = top - 2;
                Console.WriteLine("                                                    ");
                Console.WriteLine("                                                    ");
                Console.CursorTop = top - 2;
            } while (flag == true);
        }

        private static void tablefunction(double r1, double r2)
        {
            for (double x = -4; x <= 6; x += 0.2)
            {
                counter_y(r1, r2, x);

            }
        }

        private static double counter_y(double r1, double r2, double x)
        {
            x = Math.Round(x, 2);


            if (x < -4 || x > 6)
            {
                Console.WriteLine("Функция не определена");
            }

            //Первый сегмент
            if (x >= -4 && x < 0)
            {

                Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment1(x));
            }

            //Второй сегмент
            if (x == 0 && r1 != 2)
            {
                Console.WriteLine("y({0:0.00}) = {1:0.00} , {2:0.00} - точка разрыва", x, segment1(x), segment2(x, r1));
            }
            else if (x >= 0 && x < 2)
            {
                Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment2(x, r1));
            }

            //Третий сегмент
            if (x == 2 && (r1 != 2 || r2 != 2))
            {
                Console.WriteLine("y({0:0.00}) = {1:0.00} , {2:0.00} - точка разрыва", x, segment2(x, r1), segment3(x, r2));
            }
            else if (x >= 2 && x < 4)
            {
                Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment3(x, r2));
            }
            //Четвертый сегмент
            if (x == 4 && r2 != 2)
            {
                Console.WriteLine("y({0:0.00}) = {1:0.00} , {2:0.00} - точка разрыва", x, segment3(x, r2), segment4(x));
            }
            else if (x >= 4 && x <= 6)
            {
                Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment4(x));
            }


            return x;
        }

        static double segment1(double x)
        {
            double k = -0.5;
            double b = 0;
            double y = k * x + b;
            y = Math.Round(y, 2);
            return y;

        }
        static double segment2(double x, double r)
        {
            double a = 0;
            double b = 2;
            double y;
            y = -Math.Sqrt(r*r-(x-a)*(x-a))+b;
            y = Math.Round(y, 2);
            return y;
        }
        static double segment3(double x, double r)
        {
            double a = 2;
            double b = 0;
            double y;
            y = Math.Sqrt(r*r - (x - a) * (x - a)) + b;
            y = Math.Round(y, 2);
            return y;
        }
        static double segment4(double x)
        {
            double k = -1;
            double b = 4;
            double y = k*x + b;
            y = Math.Round(y, 2);
            return y;
        }
    }
}

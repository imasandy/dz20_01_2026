
public class dz20_01_2026
{
    static void Main()
    {
        Random rnd = new Random();
        int h = 0;
        int w = 0;

        Input(out h, out w);

        int[,] matrix = new int[h, w];

        while (true)
        {
            Console.Write("1. Вывод\n2. Заполнить рандомными числами" +
                "\n3. Транспонирование\n4. Заполнить цифрами 1, 2, 3...\n> ");
            string var = Console.ReadLine();
            if (var == "1")
            {
                Render(matrix);
            }
            else if (var == "2")
            {
                Random_Int(matrix, rnd);
            }
            else if (var == "3")
            {
                matrix = Transposition(matrix);
            }
            else if (var == "4")
            {
                matrix = Regular_count(matrix);
            }
        }
    }

    static void Input(out int h, out int w)
    {

        Console.Write("Введите высоту: ");

        while (!int.TryParse(Console.ReadLine(), out h) || h <= 0)
        {
            Console.WriteLine("Ошибка");
        }

        Console.Write("Введите ширину: ");

        while (!int.TryParse(Console.ReadLine(), out w) || w <= 0)
        {
            Console.WriteLine("Ошибка");
        }
    }

    static void Random_Int(int[,] matrix, Random rnd)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rnd.Next(10, 99);
            }
        }
    }

    static void Render(int[,] matrix)
    {
        int sum = 0;
        int l_sum = 0;

        int cols = matrix.GetLength(1);
        string border = new string('-', cols * 3 + 6);

        Console.WriteLine(border);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                l_sum += matrix[i, j];
                if (i == j)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    sum += matrix[i, j];
                }
                else
                {
                    Console.ResetColor();
                }
                    Console.Write($"{matrix[i, j], 3} ");
            }
            Console.ResetColor();
            Console.WriteLine($" | {l_sum}");
            l_sum = 0;
        }
        Console.WriteLine(border);
        Console.WriteLine($"Сума чисел по диагонали: {sum}");
        sum = 0;
    }

    static int[,] Transposition(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int[,] transposed = new int[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transposed[j, i] = matrix[i, j];
            }
        }
        return transposed;
    }

    static int[,] Regular_count(int[,] matrix)
    {
        int count = 1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = count;
                count++;
            }
        }
        return matrix;
    }
}


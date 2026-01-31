
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
                "\n3. Транспонирование\n4. Заполнить цифрами 1, 2, 3..." +
                "\n5. Поменять столбцы\n6. Поменять строки\n> ");

            int var;
            while (!int.TryParse(Console.ReadLine(), out var))
            {
                Console.Write("Ошибка!: ");
            }

            if (var == 1)
            {
                Render(matrix);
            }
            else if (var == 2)
            {
                RandomInt(matrix, rnd);
            }
            else if (var == 3)
            {
                matrix = Transposition(matrix);
            }
            else if (var == 4)
            {
                matrix = RegularCount(matrix);
            }
            else if (var == 5)
            {
                Console.Write("Введите номер первого столбца: ");
                int c1 = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Введите номер второго столбца: ");
                int c2 = int.Parse(Console.ReadLine()) - 1;

                if (c1 >= 0 && c1 < matrix.GetLength(1) && c2 >= 0 && c2 < matrix.GetLength(1))
                    SwapColumns(matrix, c1, c2);
                else
                    Console.WriteLine("Неверный номер столбца!");
            }
            else if (var == 6)
            {
                Console.Write("Введите номер первой строки: ");
                int r1 = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Введите номер второй строки: ");
                int r2 = int.Parse(Console.ReadLine()) - 1;

                if (r1 >= 0 && r1 < matrix.GetLength(0) && r2 >= 0 && r2 < matrix.GetLength(0))
                    SwapRows(matrix, r1, r2);
                else
                    Console.WriteLine("Неверный номер строки!");
            }
        }
    }

    static void Input(out int h, out int w)
    {

        Console.Write("Введите высоту: ");

        while (!int.TryParse(Console.ReadLine(), out h) || h <= 0)
        {
            Console.WriteLine("Ошибка: ");
        }

        Console.Write("Введите ширину: ");

        while (!int.TryParse(Console.ReadLine(), out w) || w <= 0)
        {
            Console.WriteLine("Ошибка");
        }
    }

    static void RandomInt(int[,] matrix, Random rnd)
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

    static int[,] RegularCount(int[,] matrix)
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

    static void SwapColumns(int[,] matrix, int col1, int col2)
    {
        int rows = matrix.GetLength(0);

        for (int i = 0; i < rows; i++)
        {
            int temp = matrix[i, col1];
            matrix[i, col1] = matrix[i, col2];
            matrix[i, col2] = temp;
        }
    }

    static void SwapRows(int[,] matrix, int row1, int row2)
    {
        int cols = matrix.GetLength(1);

        for (int j = 0; j < cols; j++)
        {
            int temp = matrix[row1, j];
            matrix[row1, j] = matrix[row2, j];
            matrix[row2, j] = temp;
        }
    }
}


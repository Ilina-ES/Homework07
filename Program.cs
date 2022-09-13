Start();

void Start()
{
    while (true)
    {
        Console.ReadLine();
        Console.Clear();

        System.Console.WriteLine("47) Задача 47. Задайте двумерный массив размером m*n, заполненный случайными вещественными числами.");
        System.Console.WriteLine("50) Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.");
        System.Console.WriteLine("52) Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.");
        System.Console.WriteLine("0) End");

        int numTask = SetNumber("task");

        switch (numTask)
        {
            case 0:  break;

            case 47: TwoDimensArray(); break;
            case 50: ElementSearch(); break;
            case 52: ArithmeticMean(); break;
            default: System.Console.WriteLine("error"); break;
        }
    }
}

int SetNumber(string numberName)
{
    Console.Write($"Enter number {numberName}: ");
    int num = Convert.ToInt32(Console.ReadLine());
    return num;
}

void TwoDimensArray()
{
    Console.Write("Введите количество строк массива: ");
    int rows = int.Parse(Console.ReadLine());

    Console.Write("Введите количество столбцов массива: ");
    int columns = int.Parse(Console.ReadLine()); 
    Console.WriteLine();

    double[,] array = new double[rows, columns];
    Random random = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i,j] = random.NextDouble();
            Console.Write($"{array[i, j]} ");
        }
    }
}

void ElementSearch()
{
    Console.Write("Введите количество строк массива: ");
    int rows = int.Parse(Console.ReadLine());

    Console.Write("Введите количество столбцов массива: ");
    int columns = int.Parse(Console.ReadLine()); 
    Console.WriteLine();

    int[,] array = GetArray(rows, columns, 0, 10);
    PrintArray(array);

    Console.Write("Введите число строки и число столбца через пробел: ");
    string[] number = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
    int a = int.Parse(number[0]);
    int b = int.Parse(number[1]);

    if (a > rows || b > columns)
    {
      Console.WriteLine("Такого числа в массиве нет");  
    }
    
    else
    {
        Console.WriteLine($"Данным числам соответствует элемент -> {array[a-1,b-1]}");
    }
}

int[,] GetArray(int rows, int columns, int minValue, int maxValue)
{
    int[,] result = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]} ");
        }
        Console.WriteLine();
    }
}

void ArithmeticMean()
{
    Console.Write("Введите количество строк массива: ");
    int rows = int.Parse(Console.ReadLine());

    Console.Write("Введите количество столбцов массива: ");
    int columns = int.Parse(Console.ReadLine()); 
    Console.WriteLine();

    int[,] array = GetArray(rows, columns, 0, 10);
    PrintArray(array);

    int sum = 0;
    int count = 0;
    int result = 0;

    for (int j = 0; j < array.GetLength(1); j++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            sum = sum + array[i, j];
            count++;
        }
        result = sum/count;
        Console.WriteLine($"Среднее арифмитическое чисел столбца {j+1} = {result}");
        sum = 0;
        count = 0;
    }
}
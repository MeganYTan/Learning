namespace WorkingWithMethods;

public static class ArrayManager
{
    public static int[] GenerateNumbers(int length = 10)
    {
        int[] array = new int[length];
        for (int i = 1; i <= length; i++)
        {
            array[i-1] = i;
        }

        return array;
    }

    public static void Reverse(int[] array)
    {
        for (int i = 0; i < array.Length/2; i++)
        {
            int temp = array[i];
            array[i] = array[array.Length - 1 - i];
            array[array.Length - 1 - i] = temp;
        }
    }

    public static void PrintNumbers(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + ", ");
        }
    }

    public static int Fibonacci(int number)
    {
        if (number < 2)
        {
            return 1;
        }
        int first = 1;
        int second = 1;
        for (int i = 2; i < number; i++)
        {
            int temp = first + second;
            first = second;
            second = temp;
        }

        return second;
    }
    
}

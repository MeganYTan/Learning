namespace ConsoleApp1;

public class MethodPassing
{
    public static int Add(params int[] numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        return sum;
    }

    public static int SetVar(out int a)
    {
        a = 100;
        return 0;
    }
}
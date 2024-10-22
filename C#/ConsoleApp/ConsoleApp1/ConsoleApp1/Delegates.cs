namespace ConsoleApp1;

public class Delegates
{
    

    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    delegate double MathDelegate(double a, double b);

    public static void DoDelegates()
    {
        MathDelegate md = new MathDelegate(Add);
        Console.WriteLine(md(1,2));

    }

    public static bool IsPalindrom(string s)
    {
        return s.Equals(new string(s.Reverse().ToArray()));
    }
}
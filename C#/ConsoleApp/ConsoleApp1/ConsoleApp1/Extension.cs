namespace ConsoleApp1;

public static class Extension
{
    public static bool IsEven(this int value)
    {
        if (value % 2 == 0)
        {
            return true;
            
        }
        else
        {
            return false;
        }
    }
}
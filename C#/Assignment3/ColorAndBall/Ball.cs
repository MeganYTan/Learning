namespace ColorAndBall;

public class Ball
{
    // instance variable for size, color, and number of times it has been thrown
    public int Size { get; private set; }
    public Color Color { get; }
    private int _throwCount;

    // constructors
    public Ball(int size, Color color)
    {
        Size = size;
        Color = color;
        _throwCount = 0;
    }
    
    // pop method
    public void Pop()
    {
        Size = 0;
    }
    
    // throw method
    public void Throw()
    {
        if (Size != 0)
        {
            _throwCount++;
        }
    }
    // method to return number of times ball has been thrown
    public int ThrowCount
    {
        get => _throwCount;
    }
    
}
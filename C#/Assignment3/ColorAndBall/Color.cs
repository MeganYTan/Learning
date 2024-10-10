namespace ColorAndBall;

public class Color
{
    // instance variables
    private int _red;
    private int _blue;
    private int _green;
    private int _alpha;

    // Constructor that takes red, gree, blue, and alpha values
    public Color(int red, int blue, int green, int alpha)
    {
        _red = red;
        _blue = blue;
        _green = green;
        _alpha = alpha;
    }
    // Constructor that takes red, green, blue values and sets alpha to 255
    public Color(int red, int blue, int green)
    {
        _red = red;
        _blue = blue;
        _green = green;
        _alpha = 255;
    }
    // get and set methods for color and alpha values
    public int Green
    {
        get
        {
            return _green;
        }
        set
        {
            _green = value;
        }
    }

    public int Blue
    {
        get
        {
            return _blue;
        }
        set
        {
            _blue = value;
        }
    }

    public int Red
    {
        get
        {
            return _red;
        }
        set
        {
            _red = value;
        }
    }

    public int Alpha
    {
        get
        {
            return _alpha;
        }
        set
        {
            _alpha = value;
        }
    }
    
    
    // method to get grayscale value for the color
    public double GetGrayScaleValue()
    {
        return (_red + _blue + _green) / 3;
    }
}
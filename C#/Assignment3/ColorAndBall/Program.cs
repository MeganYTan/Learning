// See https://aka.ms/new-console-template for more information
using ColorAndBall;
Color red = new Color(255, 0, 0);
Color blue = new Color(0, 255, 0);
Ball smallRedBall = new Ball(10, red);
Ball bigBlueBall = new Ball(20, blue);

Console.WriteLine($"smallRedBall has size {smallRedBall.Size} and color {smallRedBall.Color}");
smallRedBall.Throw();
smallRedBall.Throw();
smallRedBall.Throw();
Console.WriteLine($"smallRedBall has been thrown {smallRedBall.ThrowCount} times.");
smallRedBall.Pop();
Console.WriteLine($"After popping, smallRedBall has size {smallRedBall.Size}");
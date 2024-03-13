namespace blazor10.Logic;

public class DisplayImage
{
    public string Url{get;set;}
    public int Left{get;set;}
    public int Top{get;set;}
}

public class DisplayImageWithCaption : DisplayImage
{
    public string Caption{get;set;}
}

public static class DefaultImages
{
    public static List<DisplayImage> Images=[
        new DisplayImage{Url="https://via.placeholder.com/50"},
        new DisplayImageWithCaption{Url="https://via.placeholder.com/25", Caption="Subclass", Left=50, Top=50},
        new DisplayImageWithCaption{Url="https://via.placeholder.com/150", Caption="Subclass", Left=250, Top=15},
    ];

    public static List<Shape> Shapes = [
        new Rectangle((45,52), 250, 95),
        new Square((150,150), 130)
    ];

}

public class Shape
{
    public int Left{get;set;}
    public int Top{get;set;}
}

public class Rectangle : Shape
{
    public Rectangle((int top, int left) origin, int length, int width)
    {
        Left = origin.left;
        Top = origin.top;
        Length = length;
        Width = width;
    }
    public int Length{get;set;}
    public int Width{get;set;}
}

public class Square : Rectangle
{
    public Square((int top, int left) origin, int length) : base(origin, length, length)
    {

    }
    public int Length{get;set;}
    public new int Width
    {
        get => Length;
        set => Length = value;
    }
}
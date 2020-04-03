using System;

class Bullet : MovableBase
{
    public int ID
    {
        get;
        set;
    }

    public override void Clear()
    {
        Console.SetCursorPosition(prevX, prevY);
        Console.Write("  ");
        Console.SetCursorPosition(prevX + 5, prevY + 3);
        Console.Write("  ");
    }

    public override void Draw()
    {
        var prevColor = Console.ForegroundColor;
        Console.SetCursorPosition(x + 5, y);
        Console.Write("->");
        Console.SetCursorPosition(x + 5, y + 3);
        Console.Write("->");
        Console.ForegroundColor = prevColor;
    }

}
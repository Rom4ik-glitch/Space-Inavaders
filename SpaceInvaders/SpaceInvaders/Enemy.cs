using System;

class Enemy : DirectionMovableBase
{
    public Enemy(Level level, ConsoleColor color = ConsoleColor.Red)
       : base(level)
    {
        this.color = color;
        Width = 7;
        Height = 4;
    }

    public override void OnUpdate()
    {
        Move();
    }    

    public override void Clear()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write("    ");
        Console.SetCursorPosition(X, Y + 1);
        Console.Write("       ");
        Console.SetCursorPosition(X, Y + 2);
        Console.Write("       ");
        Console.SetCursorPosition(X, Y + 3);
        Console.Write("    ");
    }

    public override void Draw()
    {
        var prevColor = Console.ForegroundColor;
        Console.ForegroundColor = color;

        Console.SetCursorPosition(X, Y);
        Console.Write("<---");
        Console.SetCursorPosition(X, Y + 1);
        Console.Write(".---/ |");
        Console.SetCursorPosition(X, Y + 2);
        Console.Write("'---\\ |");
        Console.SetCursorPosition(X, Y + 3);
        Console.Write("<--");

        Console.ForegroundColor = prevColor;
    }
}
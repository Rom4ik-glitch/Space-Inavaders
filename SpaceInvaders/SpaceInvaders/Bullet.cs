using System;

class Bullet : DirectionMovableBase
{
    public static int LastID
    {
        get;
        private set;
    }


    public int ID
    {
        get;
        set;
    }

    public Bullet(Level level, ConsoleColor color = ConsoleColor.Magenta)
       : base(level)
    {
        this.color = color;
        ID = LastID++;

        Width = 2;
        Height = 1;
    }


    public override void OnUpdate() => Move();

    public override void OnHit()
    {
        //Clear();
        Game.Instance.UnRegisterBehaviour(this);
    }


    public override void Clear()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write("  ");
    }

    public override void Draw()
    {
        var prevColor = Console.ForegroundColor;

        Console.SetCursorPosition(X, Y);
        Console.Write("->");

        Console.ForegroundColor = prevColor;
    }
}
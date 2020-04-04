using System;

class Player : DirectionMovableBase
{
    public Player(Level level, ConsoleColor color = ConsoleColor.Red)
        : base(level)
    {
        this.color = color;

        Width = 7;
        Height = 4;
    }

    public override void OnUpdate()
    {
        var playerDirection = Direction.None;
        switch (Input.LastInput)
        {
            case InputResult.MoveLeft:
                playerDirection = Direction.Left;
                break;

            case InputResult.MoveRight:
                playerDirection = Direction.Right;
                break;

            case InputResult.MoveUp:
                playerDirection = Direction.Up;
                break;

            case InputResult.MoveDown:
                playerDirection = Direction.Down;
                break;

            case InputResult.Shoot:
                var bullet = new Bullet(level);

                bullet.MoveTo(X, Y);
                bullet.Move(Direction.Right);

                Game.Instance.RegisterBehaviour(bullet);
                break;
        }
        if (playerDirection != Direction.None)
        {
            Direction = playerDirection;
        }
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
        Console.Write("--->");
        Console.SetCursorPosition(X, Y + 1);
        Console.Write("| \\---.");
        Console.SetCursorPosition(X, Y + 2);
        Console.Write("| /---'");
        Console.SetCursorPosition(X, Y + 3);
        Console.Write("--->");

        Console.ForegroundColor = prevColor;
    }
}
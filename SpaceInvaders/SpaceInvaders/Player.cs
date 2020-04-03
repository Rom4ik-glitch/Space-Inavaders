using System;

class Player : MovableBase
{
    public Direction Direction
    {
        get;
        set;
    }

    protected readonly Level level;

    public Player(Level level, ConsoleColor color = ConsoleColor.Red)
    {
        this.level = level;
        this.color = color;
    }

    public void Move(Direction direction)
    {
        Direction = direction;
        switch (direction)
        {
            case Direction.Left:
                if (x > 0 && !level[x - 1, y])
                {
                    MoveTo(x - 1, y);
                }
                break;

            case Direction.Right:
                if (x < level.Width - 1 && !level[x + 7, y])
                {
                    MoveTo(x + 1, y);
                }
                break;

            case Direction.Up:
                if (y > 0 && !level[x, y - 1])
                {
                    MoveTo(x, y - 1);
                }
                break;

            case Direction.Down:
                if (y < level.Height - 1 && !level[x, y + 4])
                {
                    MoveTo(x, y + 1);
                }
                break;
        }
    }

    public void Move() => Move(Direction);

    public override void Clear()
    {
        Console.SetCursorPosition(x, y);
        Console.Write("    ");
        Console.SetCursorPosition(x, y + 1);
        Console.Write("       ");
        Console.SetCursorPosition(x, y + 2);
        Console.Write("       ");
        Console.SetCursorPosition(x, y + 3);
        Console.Write("    ");
    }

    public override void Draw()
    {
        var prevColor = Console.ForegroundColor;
        Console.ForegroundColor = color;

        Console.SetCursorPosition(x, y);
        Console.Write("--->");
        Console.SetCursorPosition(x, y + 1);
        Console.Write("| \\---.");
        Console.SetCursorPosition(x, y + 2);
        Console.Write("| /---'");
        Console.SetCursorPosition(x, y + 3);
        Console.Write("--->");

        Console.ForegroundColor = prevColor;
    }
}
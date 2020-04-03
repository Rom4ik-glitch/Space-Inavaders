using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

enum Direction
{
    None,
    Left,
    Right,
    Up,
    Down
}
 
abstract class RenderBase
{
    public abstract void Clear();
    public abstract void Draw();
}
abstract class MovableBase : RenderBase
{
    protected char cymbol;
    protected ConsoleColor color;
    protected static int x = 10;
    protected static int y = 10;
    static protected int prevX, prevY;
    static public int width, height;
    static public bool[,] field;
    static public bool isDone = false;
    public static void MoveTo(int toX,int toY)
    {
        prevX = x;
        prevY = y;
        x = toX;
        y = toY;
    }
    public static void DrawField(int width,int height)
    {

        field = new bool[width, height];
        for (int x = 0; x < width; x++)
        {
            field[x, 0] = true;
            field[x, height - 1] = true;
        }
        for (int y = 0; y < height; y++)
        {
            field[0, y] = true;
            field[width - 1, y] = true;
        }
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(field[x, y] ? "#" : " ");
            }
            Console.WriteLine();
        }
    }
    
}
class Player : MovableBase
{
    public  Direction GetInputDirection()
    {
        var keyInfo = Console.ReadKey(true);
        var direction = Direction.None;
        switch (keyInfo.Key)
        {
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                direction = Direction.Left;
                break;

            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                direction = Direction.Up;
                break;

            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                direction = Direction.Right;
                break;

            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                direction = Direction.Down;
                break;

            case ConsoleKey.Escape:
                isDone = true;
                break;
        }
        return direction;
    }
    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                if (x > 0 && !field[x - 1, y])
                {
                    MoveTo(x - 1, y);
                }
                break;

            case Direction.Right:
                if (x < width - 1 && !field[x + 7, y])
                {
                    MoveTo(x + 1, y);
                }
                break;

            case Direction.Up:
                if (y > 0 && !field[x, y - 1])
                {
                    MoveTo(x, y - 1);
                }
                break;

            case Direction.Down:
                if (y < height - 1 && !field[x, y + 4])
                {
                    MoveTo(x, y + 1);
                }
                break;
        }
    }
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
class Bullet : MovableBase
{
    public int ID { get; set; }

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



class Program
{
     static Player player = new Player();
    static void Main(string[] args)
    {
        
        Console.CursorVisible = false;
        MovableBase.DrawField(100,40);
        var inputThread = new Thread(InputThreadSheduler);
        inputThread.IsBackground = false;
        inputThread.Start();
        var playerThread = new Thread(PlayerThreadSheduler);
        playerThread.IsBackground = true;
        playerThread.Start();
        Console.ReadKey(true);

    }
    static void PlayerThreadSheduler()
    {
        while (!MovableBase.isDone)
        {
            player.Move(player.GetInputDirection());
            player.Clear();
            player.Draw(); 
            Thread.Sleep(1000 / 10);
            Console.Write("HiThere");
        }
        
    }
    static void InputThreadSheduler()
    {
        while (!MovableBase.isDone)
        {
            player.GetInputDirection();
        }
    }
}
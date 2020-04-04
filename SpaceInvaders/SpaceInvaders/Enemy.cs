using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public static void SpawnEnemy(int x, int y)
    {
        Random rnd = new Random();
        int spawn = rnd.Next(0, 100);
        if (spawn < 3)
        {
            Enemy enemy = new Enemy(level);
            enemy.Move(Direction.Left);
            enemy.MoveTo(110, rnd.Next(1, 25));
            Game.Instance.RegisterBehaviour(enemy);
        }
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

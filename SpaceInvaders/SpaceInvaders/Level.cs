using System;

class Level
{
    public int Width
    {
        get;
        protected set;
    }

    public int Height
    {
        get;
        protected set;
    }

    public bool this[int x, int y] => field[x, y];


    protected ConsoleColor color;
    protected bool[,] field;


    public Level(int width, int height, ConsoleColor color = ConsoleColor.DarkBlue)
    {
        Width = width;
        Height = height;
        this.color = color;

        CreateField();
    }

    public void DrawField()
    {
        var prevColor = Console.ForegroundColor;
        Console.ForegroundColor = color;

        Console.SetCursorPosition(0, 0);
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Console.Write(field[x, y] ? "#" : " ");
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = prevColor;
    }


    protected void CreateField()
    {
        field = new bool[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            field[x, 0] = true;
            field[x, Height - 1] = true;
        }
        for (int y = 0; y < Height; y++)
        {
            field[0, y] = true;
            field[Width - 1, y] = true;
        }
    }
}
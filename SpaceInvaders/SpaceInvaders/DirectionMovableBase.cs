abstract class DirectionMovableBase : MovableBase
{
    public Direction Direction
    {
        get;
        set;
    }

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


    protected readonly Level level;


    public DirectionMovableBase(Level level)
    {
        this.level = level;
    }


    public void Move(Direction direction)
    {
        Direction = direction;
        switch (direction)
        {
            case Direction.Left:
                if (X > 0 && !level[X - 1, Y])
                {
                    MoveTo(X - 1, Y);
                }
                else
                {
                    OnHit();
                }
                break;

            case Direction.Right:
                if (X < level.Width - 1 && !level[X + Width, Y])
                {
                    MoveTo(X + 1, Y);
                }
                else
                {
                    OnHit();
                }
                break;

            case Direction.Up:
                if (Y > 0 && !level[X, Y - 1])
                {
                    MoveTo(X, Y - 1);
                }
                else
                {
                    OnHit();
                }
                break;

            case Direction.Down:
                if (Y < level.Height - 1 && !level[X, Y + Height])
                {
                    MoveTo(X, Y + 1);
                }
                else
                {
                    OnHit();
                }
                break;
        }
    }

    public void Move() => Move(Direction);

    public virtual void OnHit() { }
}
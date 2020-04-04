abstract class MovableBase : GameBehaviourBase
{
    public int X
    {
        get;
        protected set;
    }

    public int Y
    {
        get;
        protected set;
    }

    public virtual void MoveTo(int toX, int toY)
    {
        X = toX;
        Y = toY;
    }
}
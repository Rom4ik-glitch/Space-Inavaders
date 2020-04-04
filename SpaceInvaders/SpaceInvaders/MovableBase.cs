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
    //public int Enemy_X { get; set; }
   // public int Enemy_Y { get; set; }
    public virtual void MoveTo(int toX, int toY)
    {
        X = toX;
        Y = toY;
    }
}
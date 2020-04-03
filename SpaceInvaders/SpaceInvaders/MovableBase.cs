abstract class MovableBase : RenderBase
{
    protected int x = 10;
    protected int y = 10;
    protected int prevX, prevY;

    public virtual void MoveTo(int toX, int toY)
    {
        Clear();
        prevX = x;
        prevY = y;

        x = toX;
        y = toY;
        Draw();
    }
}